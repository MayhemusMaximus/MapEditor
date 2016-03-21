using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class ListBoxItem : Control
    {

        #region Properties

        public Image Image { get; set; }
        public Label Label { get; set; }

        public bool IsSelected { get; set; }
        public Color SelectedColor { get; set; }
        public Color UnselectedColor { get; set; }

        #endregion Properties

        #region Constructors

        public ListBoxItem() : base()
        {
            base.child = this;

            this.Image = new Image();
            this.Label = new Label();

            this.ToolTipEnabled = false;
            this.ToolTip = new Tooltip();

            SelectedColor = Color.Blue;
            UnselectedColor = Color.White;
        }

        public ListBoxItem(Image image, Label label, Rectangle bounds) : base()
        {
            base.child = this;
            base.Bounds = bounds;

            this.Image = image;
            this.Label = label;

            this.ToolTipEnabled = false;
            this.ToolTip = new Tooltip();

            SelectedColor = Color.Blue;
            UnselectedColor = Color.White;
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Color drawColor = this.UnselectedColor;
            if (this.IsSelected)
                drawColor = this.SelectedColor;
            Statics.SpriteBatch.Draw(Statics.SimpleTexture, base.Bounds, drawColor);
            //Statics.SpriteBatch.Draw(Statics.SimpleTexture, base.Bounds, Color.Green);

            this.Image.Draw(gameTime);
            this.Label.Draw(gameTime);
        }

        #endregion XNA Methods


        //public event Clicked clicked;

        //protected override void OnClicked(EventArgs e)
        //{
        //    if (clicked != null)
        //        clicked(this.child, e);
        //}
    }
}
