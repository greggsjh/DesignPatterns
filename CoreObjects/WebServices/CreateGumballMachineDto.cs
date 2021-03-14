using System.ComponentModel.DataAnnotations;

namespace DesignPatterns.CoreObjects.WebServices
{
    public class CreateGumballMachineDto
    {
        [Required]
        public int Inventory { get; set; }
        [Required]
        public string Location { get; set; }
    }
}