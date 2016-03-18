using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Add Button Pressed Event
// TODO: Add Button Released Event
// TODO: Highlight button on MouseOver
// TODO: Highlight button on Pressed
// TODO: Update location of text when setting Bounds

namespace MapEditor.Controls
{
    public class Button : Control
    {

        #region Properties

        public Color Background { get; set; }

        public Control ChildControl { get; set; }

        #endregion Properties

        #region Constructors

        public Button() : base()
        {
            base.Bounds = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            base.child = this;

            Background = Color.LightGray;
            ChildControl = new Label();

            ToolTipEnabled = false;
            this.ToolTip = new Tooltip();
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Statics.SpriteBatch.Draw(Statics.SimpleTexture, Bounds, Background);

            ChildControl.Draw(gameTime);

            base.Draw(gameTime);
        }

        #endregion XNA Methods

    }
}
