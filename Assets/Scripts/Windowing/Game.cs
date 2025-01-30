using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Zephyros1938.DCSM.Demographics;
using Zephyros1938.DCSM.Political;

namespace Zephyros1938.DCSM.Windowing
{
    public class Game/*(int width, int height, string title, GameWindowSettings gameWindowSettings) */: GameWindow/*(gameWindowSettings, new NativeWindowSettings() { ClientSize = (width, height), Title = title })*/
    {
        #region Game Construcctors
        public Game(int width, int height, GameWindowSettings gameWindowSettings, string title = "DCSM Population Manager")
        : base(gameWindowSettings, CreateNativeWindowSettings(width, height, title))
        {
        }

        public Game(Vector2i size, GameWindowSettings gameWindowSettings, string title = "DCSM Population Manager")
        : base(gameWindowSettings, CreateNativeWindowSettings(size.X, size.Y, title))
        {
        }

        public Game((int X, int Y) size, GameWindowSettings gameWindowSettings, string title = "DCSM Population Manager")
        : base(gameWindowSettings, CreateNativeWindowSettings(size.X, size.Y, title))
        {
        }

        private static NativeWindowSettings CreateNativeWindowSettings(int width, int height, string title)
        {
            return new NativeWindowSettings()
            {
                ClientSize = (width, height),
                Title = title,
                StartVisible = false
            };
        }
        #endregion
        
        Party test = new Party("testParty");
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) // Update game logic here
        {
            base.OnUpdateFrame(e);

            if (!IsFocused)
            {
                return;
            }

            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }


        protected override void OnLoad() // Load graphics here
        {
            base.OnLoad();

            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Texture2D);

            //CursorState = CursorState.Grabbed;

            // Code goes here
        }

        protected override void OnRenderFrame(FrameEventArgs e) // Render graphics here
        {
            base.OnRenderFrame(e);

            SwapBuffers();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e) // Adjust the viewport when the window is resized
        {
            base.OnFramebufferResize(e);

            GL.Viewport(this.ClientRectangle);

            Console.WriteLine($"New framebuffer size: {e.Width}x{e.Height}");
        }

        protected override void OnUnload() // Clean up resources here
        {
            base.OnUnload();
        }

        /// <summary>
        /// Run the game
        /// </summary>
        public new void Run()
        {
            IsVisible = true;
            Console.WriteLine("Running the game...");
            base.Run();
        }
    }
}