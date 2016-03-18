using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

//TODO: Add ability to control text justification

namespace MapEditor.Controls
{
    public class Label : Control
    {
        #region Fields

        private string text;

        #endregion Fields

        #region Properties

        public SpriteFont SpriteFont { get; set; }
        
        public String Text
        { 
            get { return text; }
            set
            {
                text = value;
                Vector2 textsize = this.SpriteFont.MeasureString(value);
                this.Position = new Vector2(Bounds.Center.X - (textsize.X / 2), Bounds.Center.Y - (textsize.Y / 2));

            }
        }

        public Color FontColor { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default Constructor - Font: Arial 8, Bounds: (10,10,40,20), Text: Label, FontColor: Black
        /// </summary>
        public Label() : base()
        {
            base.child = this;

            this.SpriteFont = Statics.Arial_8;
            this.Bounds = new Rectangle(10, 10, 40, 20);
            this.Text = "Label";
            this.FontColor = Color.Black;
        }

        public Label(Rectangle parentBounds) : base()
        {
            base.child = this;

            this.SpriteFont = Statics.Arial_8;
            this.Bounds = parentBounds;
            this.Text = "Label";
            this.FontColor = Color.Black;
        }

        public Label(Rectangle parentBounds, SpriteFont spriteFont, String text, Color fontColor)
            : base()
        {
            base.child = this;

            this.SpriteFont = spriteFont;
            this.Bounds = parentBounds;
            this.Text = text;
            this.FontColor = fontColor;
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            Statics.SpriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, FontColor);
        }

        #endregion XNA Methods
    }
}
