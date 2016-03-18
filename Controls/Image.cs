using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class Image : Control
    {

        #region Properties

        public Color DrawColor { get; set; }

        #endregion Properties

        #region Constructors

        public Image() : base()
        {
            base.Texture = Statics.SimpleTexture;
            base.Bounds = new Microsoft.Xna.Framework.Rectangle(10, 10, 10, 10);
            base.child = this;

            DrawColor = Color.LightGoldenrodYellow;
        }

        public Image(Texture2D texture, Rectangle bounds, Color drawColor)
            : base()
        {
            base.Texture = texture;
            base.Bounds = bounds;
            base.child = this;

            DrawColor = drawColor;
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Statics.SpriteBatch.Draw(base.Texture, base.Bounds, DrawColor);
        }

        #endregion XNA Methods
    }
}
