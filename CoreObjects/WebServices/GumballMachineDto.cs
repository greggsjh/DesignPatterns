namespace DesignPatterns.CoreObjects.WebServices
{
    public class GumballMachineDto
    {
        public string Location { get; set; }
        public int Inventory { get; set; }
        public CurrentStateDto CurrentState { get; set; }
    }
}