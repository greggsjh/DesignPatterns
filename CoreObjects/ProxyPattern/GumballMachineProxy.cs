using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DesignPatterns.CoreObjects.WebServices;

namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public class GumballMachineProxy : IRemotableGumballMachine
    {
        private static HttpClient _client = new HttpClient();
        public IState CurrentState { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }

        public GumballMachineProxy(int numberOfBalls, string location)
        {
            var gumballMachine = new GumballMachine(numberOfBalls, location);
            var getResponse = _client.GetAsync($"https://localhost:5001/api/gumballmachine/{location}").Result;
            if (getResponse.IsSuccessStatusCode)
            {
                var getGumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(getResponse.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Location = getGumballMachineDto.Location;
                Count = getGumballMachineDto.Inventory;
                CurrentState = StateFactory(getGumballMachineDto.CurrentState.Name, gumballMachine);
            }
            else if (getResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var createGumballMachineDto = new CreateGumballMachineDto { Location = location, Inventory = numberOfBalls };
                HttpContent content = new StringContent(JsonSerializer.Serialize(createGumballMachineDto), Encoding.UTF8, "application/json");
                var response = _client.PostAsync("https://localhost:5001/api/gumballmachine", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"An error has occurred. HTTP status code: {response.StatusCode}");
                }

                var gumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(response.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Location = gumballMachineDto.Location;
                Count = gumballMachineDto.Inventory;
                CurrentState = StateFactory(gumballMachineDto.CurrentState.Name, gumballMachine);
            }
        }

        private IState StateFactory(string name, GumballMachine gumballMachine)
        {
            switch (name)
            {
                case "HasQuarterState":
                    return new HasQuarterState(gumballMachine);
                case "NoQuarterState":
                    return new NoQuarterState(gumballMachine);
                case "SoldOutState":
                    return new SoldOutState(gumballMachine);
                case "SoldState":
                    return new SoldState(gumballMachine);
                case "WinnerState":
                    return new WinnerState(gumballMachine);
                default:
                    throw new Exception($"An error has occurred.");
            }
        }
    }
}