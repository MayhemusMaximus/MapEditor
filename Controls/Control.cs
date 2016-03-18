using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class Control
    {
        #region Fields

        protected object child;

        public bool mouseIsOver;
        public bool mouseWasOver;

        public Vector2 Size = new Vector2(40, 20);
        public Vector2 Position = new Vector2(10, 10);
        public Texture2D Texture;

        #endregion Fields

        #region Properties

        public Rectangle Bounds
        {
            get { return new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y); }
            set
            {
                this.Position.X = value.X;
                this.Position.Y = value.Y;
                this.Size.X = value.Width;
                this.Size.Y = value.Height;
            }
        }
        public Boolean ToolTipEnabled { get; set; }
        public Tooltip ToolTip { get; set; }

        #endregion Properties

        #region Events

        #region MouseEnter

        public delegate void MouseEnter(object sender, EventArgs e);
        public event MouseEnter mouseEnter;
        public virtual void OnMouseEnter(EventArgs e)
        {
            if (mouseEnter != null)
                mouseEnter(this.child, e);
        }

        #endregion MouseEnter

        #region MouseOver

        public delegate void MouseOver(object sender, EventArgs e);
        public event MouseOver mouseOver;
        public virtual void OnMouseOver(EventArgs e)
        {
            if (mouseOver != null)
                mouseOver(this.child, e);
        }

        #endregion MouseOver

        #region MouseLeave

        public delegate void MouseLeave(object sender, EventArgs e);
        public event MouseLeave mouseLeave;
        public virtual void OnMouseLeave(EventArgs e)
        {
            if (mouseLeave != null)
                mouseLeave(this.child, e);
        }

        #endregion MouseLeave

        #region Click

        public delegate void Clicked(object sender, EventArgs e);
        public event Clicked clicked;
        public virtual void OnClicked(EventArgs e)
        {
            if (clicked != null)
                clicked(this.child, e);
        }

        #endregion Click

        #endregion Events

        #region Constructors

        public Control()
        {

        }

        #endregion Constructors

        public virtual void Update(GameTime gameTime)
        {
            handleInputEvents();
            if (ToolTipEnabled)
                this.ToolTip.Update(gameTime);
        }

        private void handleInputEvents()
        {
            handleMouseEvents();
        }

        private void handleMouseEvents()
        {
            handleMousePositionEvents();
            handleMouseButtonEvents();
        }

        private void handleMousePositionEvents()
        {
            mouseWasOver = mouseIsOver;
            mouseIsOver = Statics.isMouseInBounds(this.Bounds);

            if (!mouseWasOver && mouseIsOver)
            {
                OnMouseEnter(EventArgs.Empty);

                if (this.ToolTipEnabled)
                    this.ToolTip.Active = true;
                return;
            }

            if (mouseWasOver && mouseIsOver)
            {
                OnMouseOver(EventArgs.Empty);
                return;
            }

            if (mouseWasOver && !mouseIsOver)
            {
                OnMouseLeave(EventArgs.Empty);

                if (ToolTipEnabled)
                    this.ToolTip.Active = false;
                return;
            }
        }

        private void handleMouseButtonEvents()
        {
            if (mouseIsOver)
            {
                if(Statics.PreviousMouseState.LeftButton == ButtonState.Pressed
                    && Statics.CurrentMouseState.LeftButton == ButtonState.Released)
                    OnClicked(EventArgs.Empty);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (this.ToolTipEnabled)
                this.ToolTip.Draw(gameTime);
        }
    }
}
