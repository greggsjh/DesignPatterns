namespace DesignPatterns.CommandPattern
{
    public class LightOnCommand : ICommand
    {
        public LightOnCommand(Light light)
        {
            Light = light;
        }
        public Light Light { get; private set; }

        public string Execute()
        {
            return Light.On();
        }

        public string Undo()
        {
            return Light.Off();
        }
    }
}