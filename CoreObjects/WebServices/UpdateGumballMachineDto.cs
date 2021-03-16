namespace DesignPatterns.CoreObjects.WebServices
{
    public class UpdateGumballMachineDto
    {
        public string Location { get; set; }
        public int Inventory { get; set; }
        public CurrentStateDto CurrentState { get; set; }
    }
}