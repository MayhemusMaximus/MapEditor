using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Create EventArgs Classes for Each Event.

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

        // TODO: Implement Rotation in Draw Methods
        public double Rotation { get; set; }

        #endregion Properties

        #region Events

        #region MouseEnter

        public delegate void MouseEnter(object sender, System.EventArgs e);
        public event MouseEnter mouseEnter;
        public virtual void OnMouseEnter(System.EventArgs e)
        {
            if (mouseEnter != null)
                mouseEnter(this.child, e);
        }

        #endregion MouseEnter

        #region MouseOver

        public delegate void MouseOver(object sender, System.EventArgs e);
        public event MouseOver mouseOver;
        public virtual void OnMouseOver(System.EventArgs e)
        {
            if (mouseOver != null)
                mouseOver(this.child, e);
        }

        #endregion MouseOver

        #region MouseLeave

        public delegate void MouseLeave(object sender, System.EventArgs e);
        public event MouseLeave mouseLeave;
        protected virtual void OnMouseLeave(System.EventArgs e)
        {
            if (mouseLeave != null)
                mouseLeave(this.child, e);
        }

        #endregion MouseLeave

        #region Click

        public delegate void Released(object sender, EventArgs.LeftMousebuttonReleasedEventArgs e);
        public event Released leftMouseButtonReleased;
        protected virtual void OnClicked(EventArgs.LeftMousebuttonReleasedEventArgs e)
        {
            if (leftMouseButtonReleased != null)
                leftMouseButtonReleased(this.child, e);
        }

        #region LeftMouseButtonPressed

        public delegate void LeftMouseButtonPressed(object sender, EventArgs.LeftMouseButtonPressedEventArgs e);
        public event LeftMouseButtonPressed leftMousebuttonPressed;
        protected virtual void OnLeftMouseButtonPressed(EventArgs.LeftMouseButtonPressedEventArgs e)
        {
            if (leftMousebuttonPressed != null)
                leftMousebuttonPressed(this.child, e);
        }

        #endregion LeftMouseButtonPressed

        #region RightMouseButtonReleased

        public delegate void RightMouseButtonRelease(object sender, EventArgs.LeftMousebuttonReleasedEventArgs e);
        public event RightMouseButtonRelease rightMouseButtonReleased;
        protected virtual void OnRightMouseButtonReleased(EventArgs.LeftMousebuttonReleasedEventArgs e)
        {
            if (rightMouseButtonReleased != null)
            {
                rightMouseButtonReleased(this.child, e);
            }
        }

        #endregion RightMouseButtonReleased

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
                OnMouseEnter(System.EventArgs.Empty);

                if (this.ToolTipEnabled)
                    this.ToolTip.Active = true;
                return;
            }

            if (mouseWasOver && mouseIsOver)
            {
                OnMouseOver(System.EventArgs.Empty);
                return;
            }

            if (mouseWasOver && !mouseIsOver)
            {
                OnMouseLeave(System.EventArgs.Empty);

                if (ToolTipEnabled)
                    this.ToolTip.Active = false;
                return;
            }
        }

        private void handleMouseButtonEvents()
        {
            if (mouseIsOver)
            {
                if (Statics.PreviousMouseState.LeftButton == ButtonState.Released
                    && Statics.CurrentMouseState.LeftButton == ButtonState.Pressed)
                    OnLeftMouseButtonPressed(new EventArgs.LeftMouseButtonPressedEventArgs());

                if(Statics.PreviousMouseState.LeftButton == ButtonState.Pressed
                    && Statics.CurrentMouseState.LeftButton == ButtonState.Released)
                    OnClicked(new EventArgs.LeftMousebuttonReleasedEventArgs());
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (this.ToolTipEnabled)
                this.ToolTip.Draw(gameTime);
        }
    }
}
