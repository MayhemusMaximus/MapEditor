using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class Tooltip : Control
    {
        #region Fields

        private bool active = false;
        private int currentDelay = 0;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Time to wait before tooltip displays represented in milliseconds.
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Text displayed when tooltip is visible.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color of the tooltip text.
        /// </summary>
        public Color FontColor { get; set; }

        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                if (!active)
                    currentDelay = 0;
            }
        }

        #endregion Properties

        #region Constructors

        public Tooltip() : base()
        {
            base.child = this;

            this.FontColor = Color.Black;
            this.Delay = 500;
            this.Text = "Tooltip needs to be set.";
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            if (active)
                currentDelay += gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void Draw(GameTime gameTime)
        {
            if (active && currentDelay > Delay)
                Statics.SpriteBatch.DrawString(Statics.Arial_8, this.Text, new Vector2((int)Statics.CurrentMouseState.X + 20, (int)Statics.CurrentMouseState.Y + 20), FontColor);
        }



        #endregion XNA Methods
    }
}
