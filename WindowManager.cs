using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace CustomEngine
{
    public class WindowManager : GameWindow
    {
        // Essentials

        public static GameWindow gameWindow;
        public int width, height;

        public float r, g, b, a;
        public string title { get { return title; } set { base.Title = value; } }

        public bool vSync { get { return vSync; } set { VSync(value); } }
        public bool resize;
        public Matrix4 projMat;

        public WindowManager(int width, int height, string title, bool vSync) 
            : base(GameWindowSettings.Default, new NativeWindowSettings 
            {
                Title = title,
                ClientSize = new Vector2i(width, height),
                APIVersion = new Version(4, 5),      // OpenGL version 4.5
                Flags = ContextFlags.ForwardCompatible, // Forward-compatible context
                WindowBorder = WindowBorder.Resizable,
                StartVisible = true,
                StartFocused = true,
                Profile = ContextProfile.Core       // Core profile
            })
        {
            projMat = new Matrix4();
            
            CenterWindow(new Vector2i(width, height));
        }

        
        
        protected override void OnLoad()
        //bublic void init() {
        {
            base.OnLoad();

            gameWindow = this;

            //setting up err callback
            GL.Enable(EnableCap.DebugOutput);
            GL.Enable(EnableCap.DebugOutputSynchronous);
            GL.DebugMessageCallback(OpenGLErrorCallback, IntPtr.Zero);
            //GL.DebugMessageControl(DebugSourceControl.DontCare, DebugTypeControl.DontCare, DebugSeverityControl.DebugSeverityNotification, 0, IntPtr.Zero, false);

            // Enable important stuff
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.StencilTest);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            VSync(true);

            //where's the alpha test?

            Console.WriteLine("HI");
        }

        protected VSyncMode VSync(bool m)
        {
            if (m) return VSyncMode.On;
            else return VSyncMode.Off;
        }

        private static void OpenGLErrorCallback(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr message, IntPtr userParam)
        {
            string errorMessage = Marshal.PtrToStringAnsi(message, length);
            Console.WriteLine($"OpenGL Error: Source={source}, Type={type}, Severity={severity}, Message={errorMessage}");
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            gameWindow = null;
            Launcher.Window = null;
            Console.WriteLine("BYE");
            

        }

        float multiplier = 0.001f;
        protected override void OnRenderFrame(FrameEventArgs args)
        //called every frame, used for all RENDERING
        {
            base.OnRenderFrame(args);
            r = 0.0001f;
            if (r >= 1.0f || r <= 0f)
            {
                
                multiplier = -multiplier;
            } else
            {
                r += multiplier;
            }
            GL.ClearColor(r, g, b, a);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);


        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        //also called every frame, used for all UPDATING
        {
            base.OnUpdateFrame(args);
            Context.SwapBuffers();

        }


        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Keys.Escape)
            {
                Console.WriteLine("Esc");
            }
        }

        public Matrix4 UpdateProjMat()
        //Used to transfer projmat to unif
        {
            float aspectRatio = (float)this.width / this.height;
            Matrix4 mat = projMat;
            return mat *= Matrix4.CreatePerspectiveFieldOfView(Settings.FOV, aspectRatio, Settings.Z_NEAR, Settings.Z_FAR);
        }






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
        ~WindowManager()
        {
            Dispose(false);
        }
    }
}
