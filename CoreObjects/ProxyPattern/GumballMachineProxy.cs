using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using DesignPatterns.CoreObjects.Helpers;
using DesignPatterns.CoreObjects.WebServices;

namespace DesignPatterns.CoreObjects.ProxyPattern
{
    public class GumballMachineProxy : IRemotableGumballMachine
    {
        private static HttpClient _client = new HttpClient();

        private IRemotableGumballMachine _remoteMachine;

        public IState CurrentState
        {
            get
            {
                var getResponse = _client.GetAsync($"https://localhost:5001/api/gumballmachine/{_remoteMachine.Location}").Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    var getGumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(getResponse.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return Helper.StateFactory(getGumballMachineDto.CurrentState.Name, (GumballMachine)_remoteMachine);
                }
                return null;
            }
        }

        public string Location
        {
            get
            {
                var getResponse = _client.GetAsync($"https://localhost:5001/api/gumballmachine/{_remoteMachine.Location}").Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    var getGumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(getResponse.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return getGumballMachineDto.Location;
                }
                return string.Empty;
            }
        }

        public int Count
        {
            get
            {
                var getResponse = _client.GetAsync($"https://localhost:5001/api/gumballmachine/{_remoteMachine.Location}").Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    var getGumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(getResponse.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return getGumballMachineDto.Inventory;
                }
                return 0;
            }
        }

        public GumballMachineProxy(int numberOfBalls, string location)
        {
            var getResponse = _client.GetAsync($"https://localhost:5001/api/gumballmachine/{location}").Result;
            if (getResponse.IsSuccessStatusCode)
            {
                var getGumballMachineDto = JsonSerializer.Deserialize<GumballMachineDto>(getResponse.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _remoteMachine = new GumballMachine(getGumballMachineDto.Inventory, getGumballMachineDto.Location);
                ((GumballMachine)_remoteMachine).CurrentState = Helper.StateFactory(getGumballMachineDto.CurrentState.Name, new GumballMachine(getGumballMachineDto.Inventory, getGumballMachineDto.Location));
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
                _remoteMachine = new GumballMachine(gumballMachineDto.Inventory, gumballMachineDto.Location);
                ((GumballMachine)_remoteMachine).CurrentState = Helper.StateFactory(gumballMachineDto.CurrentState.Name, new GumballMachine(gumballMachineDto.Inventory, gumballMachineDto.Location));
            }
        }
    }
}