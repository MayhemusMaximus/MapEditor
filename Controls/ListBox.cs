using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor.Controls
{
    public class ListBox : Control
    {
        #region Properties

        public List<ListBoxItem> ListBoxItems { get; set; }
        public int SelectedItem { get; set; }

        public int ItemHeight { get; set; }
        public int ItemPadding { get; set; }

        #endregion Properties

        #region Constructors

        public ListBox() : base()
        {
            base.child = this;

            ListBoxItems = new List<ListBoxItem>();
            this.ItemHeight = 30;
            this.ItemPadding = 5;
        }

        #endregion Constructors

        #region XNA Methods

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            Statics.SpriteBatch.Draw(Statics.SimpleTexture, base.Bounds, Color.White);

            foreach(ListBoxItem listBoxItem in ListBoxItems)
            {
                listBoxItem.Draw(gameTime);
            }
        }

        #endregion XNA Methods

        #region Helper Methods

        public void AddNewListBoxItem(Texture2D texture, string text, Color imageColor)
        {
            int index = ListBoxItems.Count();

            int imageX = base.Bounds.X + this.ItemPadding;
            int imageY = base.Bounds.Y + this.ItemPadding + (index * this.ItemHeight);
            int imageWidth = this.ItemHeight - this.ItemPadding;
            Rectangle imageBounds = new Rectangle(imageX, imageY, imageWidth, imageWidth);
            //TODO: Change the image Color back to White and Remove the argument
            Image image = new Image(texture, imageBounds, imageColor);

            int parentX = imageX + this.ItemPadding;
            int parentY = imageY;
            int labelWidth = base.Bounds.Width - imageWidth - (this.ItemPadding * 3);
            int labelHeight = this.ItemHeight;
            Rectangle parentBounds = new Rectangle(parentX, parentY, labelWidth, labelHeight);
            Label label = new Label(parentBounds, Statics.Arial_8, text, Color.Black);

            ListBoxItem listBoxItem = new ListBoxItem(image, label);

            listBoxItem.clicked += listBoxItem_clicked;

            this.ListBoxItems.Add(listBoxItem);

        }

        void listBoxItem_clicked(object sender, EventArgs e)
        {
            foreach(ListBoxItem listBoxItem in ListBoxItems)
            {
                if (listBoxItem.IsSelected)
                    listBoxItem.IsSelected = false;
            }

            ((ListBoxItem)sender).IsSelected = true;
        }

        #endregion Helper Methods
    }
}
