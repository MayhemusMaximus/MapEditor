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

        public ListBoxItem getSelectedListBoxItem
        {
            get
            {
                foreach (ListBoxItem listBoxItem in ListBoxItems)
                {
                    if (listBoxItem.IsSelected)
                        return listBoxItem;
                }
                return null;
            }
        }

        #endregion Properties

        #region Events

        public delegate void selectedItemChanged(object sender, EventArgs.SelectedListBoxItemChangedEventArgs e);
        public event selectedItemChanged SelectedItemChanged;
        protected virtual void OnSelectedItemChanged(EventArgs.SelectedListBoxItemChangedEventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, e);
        }

        #endregion Events

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
            foreach (ListBoxItem listBoxItem in ListBoxItems)
            {
                listBoxItem.Update(gameTime);
            }
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

        public void AddNewListBoxItem(Texture2D texture, string text)
        {
            int index = ListBoxItems.Count();

            int imageX = base.Bounds.X + this.ItemPadding;
            int imageY = base.Bounds.Y + this.ItemPadding + (index * this.ItemHeight);
            int imageWidth = this.ItemHeight - this.ItemPadding;
            Rectangle imageBounds = new Rectangle(imageX, imageY, imageWidth, imageWidth);
            Image image = new Image(texture, imageBounds, Color.White);

            int parentX = imageX + this.ItemPadding;
            int parentY = imageY;
            int labelWidth = base.Bounds.Width - imageWidth - (this.ItemPadding * 3);
            int labelHeight = this.ItemHeight;
            Rectangle parentBounds = new Rectangle(parentX, parentY, labelWidth, labelHeight);
            Label label = new Label(parentBounds, Statics.Arial_8, text, Color.Black);

            int itemX = this.Bounds.X;
            int itemY = this.Bounds.Y + (this.ItemHeight * index);
            int itemWidth = this.Bounds.Width;
            int itemHeight = this.ItemHeight;
            Rectangle listBoxItemBounds = new Rectangle(itemX,itemY,itemWidth,ItemHeight);
            ListBoxItem listBoxItem = new ListBoxItem(image, label, listBoxItemBounds);

            listBoxItem.leftMouseButtonReleased += listBoxItem_clicked;

            this.ListBoxItems.Add(listBoxItem);

        }

        private void listBoxItem_clicked(object sender, EventArgs.LeftMousebuttonReleasedEventArgs e)
        {
            List<ListBoxItem> previouslySelectedItems = new List<ListBoxItem>();
            foreach (ListBoxItem listBoxItem in ListBoxItems)
            {
                if (listBoxItem.IsSelected)
                {
                    previouslySelectedItems.Add(listBoxItem);
                    listBoxItem.IsSelected = false;
                }
            }

            List<ListBoxItem> newlySelectedItems = new List<ListBoxItem>();
            newlySelectedItems.Add((ListBoxItem)sender);
            ((ListBoxItem)sender).IsSelected = true;


            OnSelectedItemChanged(new EventArgs.SelectedListBoxItemChangedEventArgs(previouslySelectedItems, newlySelectedItems));
        }

        #endregion Helper Methods
    }
}
