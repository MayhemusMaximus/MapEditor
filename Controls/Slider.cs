using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MapEditor.Controls
{
    public class Slider : Control
    {
        #region Fields

        private bool active;

        private int minCenterY;
        private int maxCenterY;

        #endregion Fields

        #region Properties

        public int Padding { get; set; }

        public Image Groove { get; set; }
        public Image Knob { get; set; }

        public double MinValue { get; set; }
        public double Value { get; set; }
        public double MaxValue { get; set; }

        #endregion Properties

        #region Constructors

        public Slider()
        {
            this.Bounds = new Rectangle(10, 10, 20, 120);
            base.child = this;

            Padding = 5;

            MinValue = 0;
            Value = 0;
            MaxValue = 100;

            Groove = new Image(Statics.SimpleTexture, base.Bounds, Color.PapayaWhip);
            Knob = new Image(Statics.SimpleTexture, new Rectangle((int)base.Bounds.X + Padding, (int)base.Bounds.Y + Padding, 10, 10), Color.RosyBrown);

            minCenterY = Knob.Bounds.Center.X;
            maxCenterY = (int)base.Bounds.Bottom - Padding - ((int)Knob.Size.Y / 2);

            active = false;
            Knob.leftMousebuttonPressed += Knob_leftMousebuttonPressed;
            Knob.leftMouseButtonReleased += Knob_leftMouseButtonReleased;
        }

        #endregion Constructors

        #region Event Handlers

        private void Knob_leftMousebuttonPressed(object sender, EventArgs.LeftMouseButtonPressedEventArgs e)
        {
            active = true;
        }

        private void Knob_leftMouseButtonReleased(object sender, EventArgs.LeftMousebuttonReleasedEventArgs e)
        {
            active = false;
        }

        #endregion Event Handlers

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Groove.Update(gameTime);
            Knob.Update(gameTime);

            if (active)
            {
                moveKnob();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            Groove.Draw(gameTime);
            Knob.Draw(gameTime);

            Statics.SpriteBatch.DrawString(Statics.Arial_8, Value.ToString(), new Vector2(base.Bounds.X, base.Bounds.Bottom + 10), Color.Pink);
        }

        #endregion XNA Methods

        #region Helper Methods

        private void moveKnob()
        {
            Point mousePoint = Statics.getCurrentMousePoint();
            if (mousePoint.Y > base.Bounds.Y + Padding + (Knob.Size.Y / 2)
                && mousePoint.Y < base.Bounds.Bottom - Padding - (Knob.Size.Y / 2))
            {
                Knob.Bounds = new Rectangle(Knob.Bounds.X, (int)mousePoint.Y - (int)(Knob.Size.Y / 2), (int)Knob.Size.X, (int)Knob.Size.Y);

                int sliderRange = maxCenterY - minCenterY;
                Value = sliderRange / 100 * (Knob.Bounds.Center.Y - minCenterY);
                OnSliderValueChanged(new EventArgs.SliderValueChangedEventArgs(Value));
                return;
            }

            if (mousePoint.Y < base.Bounds.Y + (Knob.Size.Y / 2))
            {
                Value = MinValue;
                OnSliderValueChanged(new EventArgs.SliderValueChangedEventArgs(Value));
                return;
            }

            if (mousePoint.Y > base.Bounds.Bottom - Padding - (Knob.Size.Y / 2))
            {
                OnSliderValueChanged(new EventArgs.SliderValueChangedEventArgs(Value));
                Value = MaxValue;
            }
        }

        #endregion Helper Methods

        #region Events

        public delegate void SliderValueChanged(object sender, EventArgs.SliderValueChangedEventArgs e);
        public event SliderValueChanged sliderValueChanged;
        protected virtual void OnSliderValueChanged(EventArgs.SliderValueChangedEventArgs e)
        {
            if (sliderValueChanged != null)
                sliderValueChanged(this, e);
        }

        #endregion
    }
}
