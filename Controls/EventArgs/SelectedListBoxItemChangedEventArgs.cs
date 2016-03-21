using System;
using System.Collections.Generic;

// TODO: Add index field to ListBoxItem
namespace MapEditor.Controls.EventArgs
{
    public class SelectedListBoxItemChangedEventArgs : System.EventArgs
    {
        public List<ListBoxItem> PreviouslySelectedListBoxItems { get; private set; }
        public List<ListBoxItem> NewlySelectedListBoxItems { get; private set; }

        public SelectedListBoxItemChangedEventArgs(List<ListBoxItem> previouslySelectedListBoxItems,
                                            List<ListBoxItem> newlySelectedListBoxItems)
        {
            this.PreviouslySelectedListBoxItems = previouslySelectedListBoxItems;
            this.NewlySelectedListBoxItems = newlySelectedListBoxItems;
        }
    }
}
