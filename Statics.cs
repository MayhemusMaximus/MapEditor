using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public static class Statics
    {
        public static GraphicsDevice GraphicsDevice;
        public static GraphicsAdapter Adapter;
        public static SpriteBatch SpriteBatch;
        public static GraphicsDeviceManager Graphics;
        public static ContentManager Content;
        public static GameTime GameTime;

        #region Fonts

        public static SpriteFont Arial_8;

        #endregion Fonts

        #region States

        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviouseKeyboardState;

        public static MouseState CurrentMouseState;
        public static MouseState PreviousMouseState;

        #endregion States

        public static Texture2D SimpleTexture;

        public static void InitializeStatics(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            BuildSimpleTexture();
        }

        private static void BuildSimpleTexture()
        {
            SimpleTexture = new Texture2D(GraphicsDevice, 1, 1);

            Texture2D hold = new Texture2D(GraphicsDevice, 1, 1);
            Color[] colors = new Color[1];
            hold.GetData(colors);

            colors[0] = Color.White;

            SimpleTexture.SetData(colors);
        }

        public static bool isMouseInBounds(Rectangle bounds)
        {
            return bounds.Contains(getCurrentMousePoint());
        }

        public static Point getCurrentMousePoint()
        {
            return new Point((int)Statics.CurrentMouseState.X, (int)Statics.CurrentMouseState.Y);
        }
    }
}
