using System.Diagnostics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Zephyros1938.DCSM.Windowing;
namespace Zephyros1938.DCSM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.High;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Could not set system priority to high.");
            }
            using (var game = new Game(Resolutions.Medium_1280x720, GameWindowSettings.Default, "DCSM Population Simulation"))
            {
                game.WindowBorder = WindowBorder.Fixed;
                // Center the window on the screen
                game.CenterWindow();

                // Run the game
                game.Run();
            }
        }

        public void GetCredits()
        {
            
        }
    }
}