using Loging;

namespace TPA_Etap_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Logger Log = new Logger("../../../Log.txt");

            IDisplayHandler displayHandler = new ConsoleHandler();
            displayHandler.DisplayMenu();
        }
    }
}
