using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class Tab : Control
    {
        #region Fields

        public Button Button;
        public List<Control> Controls;

        #endregion Fields

        #region Properties

        public Boolean IsActive { get; set; }

        #endregion Properties

        #region Events

        public delegate void TabClicked(object sender, EventArgs e);
        public event TabClicked tabClicked;

        #endregion Events

        #region Constructors

        public Tab(Rectangle parentBounds, int padding, Button button)
        {
            Bounds = new Rectangle(parentBounds.X + padding, parentBounds.Y + padding, parentBounds.Width - (padding * 2), parentBounds.Height - padding);
            this.Button = button;

            Controls = new List<Control>();

            IsActive = false;

            Button.clicked += Button_clicked;
        }

        void Button_clicked(object sender, EventArgs e)
        {
            if (tabClicked != null)
                tabClicked(this, EventArgs.Empty);
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            foreach(Control control in Controls)
            {
                control.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(Control control in Controls)
            {
                control.Draw(gameTime);
            }
        }

        #endregion XNA Methods
    }
}
