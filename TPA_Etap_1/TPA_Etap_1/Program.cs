namespace TPA_Etap_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDisplayHandler displayHandler = new ConsoleHandler();
            displayHandler.DisplayMenu();
        }
    }
}
