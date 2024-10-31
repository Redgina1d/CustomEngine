using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEngine
{
    public class EngineManager : IDisposable
    {
        public static long NANOSECOND = 1000000000L;
        public static long FRAMERATE = 1000;

        private static int fps;
        public static float frametime = 1.0f / FRAMERATE;

        private bool isRunning;

        private WindowManager window;
        private MouseInput mouseInput;
        // err callback ?
        private Logic gameLogic;

        private void init()
        {
            window = Launcher.Window;
            //LOGIC
            //INITS
        }

        public void start()
        {
            init();
            if (isRunning)
                return;
            run();
        }

        private void run()
        {
            this.isRunning = true;
            int frames = 0;
            long frameCounter = 0;
            long lastTime = Stopwatch.GetTimestamp();
            double unprocessedTime = 0;

            while (isRunning && (window != null))
            {
                bool render = false;
                long startTime = Stopwatch.GetTimestamp();
                long passedTime = startTime - lastTime;
                lastTime = startTime;

                unprocessedTime += passedTime / (double)NANOSECOND;
                frameCounter += passedTime;

                //input

                while (unprocessedTime > frametime)
                {
                    render = true;
                    unprocessedTime -= frametime;
                    
                    if (window == null)
                    {
                        //stop
                    }

                    if (frameCounter >= NANOSECOND)
                    {
                        setFps(frames);
                        Launcher.Window.title = ($"Current FPS: {fps}");
                        frames = 0;
                        frameCounter = 0;
                    }
                }

                if (render)
                {
                    update();
                    //render
                    frames++;
                }
            }
            //cleanup
        }

        private void stop()
        {
            if (isRunning)
                return;
            isRunning = false;
        }

        private void input()
        {
            //mouse gamelogic
        }

        private void render()
        {
            //logic render & window update
        }

        private void update()
        {
            gameLogic.update(Settings.MOUSE_SENSITIVITY, mouseInput);
        }

        public static int getFps()
        {
            return fps;
        }

        public static void setFps(int fps)
        {
            EngineManager.fps = fps;
        }

        /// CLEANUP ///
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //
                }
                // 
                disposed = true;
            }
        }
        ~EngineManager()
        {
            Dispose(false);
        }
    }
}
