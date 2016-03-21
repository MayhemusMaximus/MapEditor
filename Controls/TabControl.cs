using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Add buttons for scrolling left and right in the tab buttons when there are too many tabs to fit in controls bounds.

namespace MapEditor.Controls
{
    public class TabControl : Control
    {
        #region Fields

        //private List<Button> tabs = new List<Button>();
        public List<Tab> tabs = new List<Tab>();

        #endregion Fields

        #region Properties

        public Color Background { get; set; }

        #endregion Properties

        #region Constructors

        public TabControl() : base()
        {
            Bounds = new Rectangle(10, 10, 100, 100);
            Background = Color.DarkGray;

            AddTab();
            AddTab();

            tabs[0].IsActive = true;
        }

        #endregion Constructors

        #region Helper Methods

        public void AddTab()
        {
            // Creating a new button
            Button button = new Button();
            button.ToolTipEnabled = true;
            int id = tabs.Count;
            string text = "Tab " + id;
            // Tooltip for button
            Controls.Tooltip tooltip = new Controls.Tooltip();
            tooltip.Delay = 500;
            tooltip.FontColor = Color.IndianRed;
            tooltip.Text = text;
            button.ToolTip = tooltip;
            Rectangle bounds = new Rectangle((int)Bounds.X + ((int)button.Size.X * tabs.Count), (int)Bounds.Height - (int)button.Size.Y, (int)button.Size.X, (int)button.Size.Y);
            button.Bounds = bounds;
            Label label = new Label(bounds, Statics.Arial_8, text, Color.Black);
            button.ChildControl = label;

            Tab tab = new Tab(Bounds, 5, button);
            tabs.Add(tab);

            tab.tabClicked += tab_tabClicked;
        }

        void tab_tabClicked(object sender, System.EventArgs e)
        {
            foreach(Tab tab in tabs)
            {
                if(tab.IsActive)
                {
                    tab.IsActive = false;
                    break;
                }
            }
            ((Tab)sender).IsActive = true;
        }

        #endregion Helper Methods

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            foreach (Tab tab in tabs)
            {
                tab.Button.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Statics.SpriteBatch.Draw(Statics.SimpleTexture, Bounds, Background);

            foreach (Tab tab in tabs)
            {
                tab.Button.Draw(gameTime);
                if(tab.IsActive)
                {
                    tab.Draw(gameTime);
                }
            }
        }

        #endregion XNA Methods
    }
}
