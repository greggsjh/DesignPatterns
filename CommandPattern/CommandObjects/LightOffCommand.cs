namespace DesignPatterns.CommandPattern
{
    public class LightOffCommand : ICommand
    {
        public LightOffCommand(Light light)
        {
            Light = light;
        }

        public Light Light { get; set; }
        public string Execute()
        {
            return Light.Off();
        }
    }
}