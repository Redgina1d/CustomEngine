
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace CustomEngine
{

    public class Launcher
    {
        public static WindowManager Window { get; set; }
        //test game

        static void Main(string[] args)
        {
            using (WindowManager window = new WindowManager(500, 500, "lol", true))
            {
                Window = window;
                window.Run();
            }
            using (EngineManager engine = new())
            {
                try
                {
                    engine.start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
