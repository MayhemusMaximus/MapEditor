using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Controls = MapEditor.Controls;

// Components
// TODO: Write Listbox Control
// TODO: Write Drop Down Control
// TODO: Write Scrollbar Control
// TODO: Write a Tooltip Control

// TODO: Add Menu Bar
// TODO: Add Menu Items
// TODO: Add Tool Bar
// TODO: Add Tools
// TODO: Add scrollable window with MDI stile tabs for maps
// TODO: Add window with tabs for Mini-map, Objects, and Layers
// TODO: Add scrollable window with tabs for Terrains and Tilesets
// TODO: Add logic to create map files.

namespace MapEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Editor : Microsoft.Xna.Framework.Game
    {

        Controls.Button button;

        //tabControl Test
        Controls.TabControl tabControl;

        ////listbox Test
        //Controls.ListBox listbox;

        public Editor()
        {
            Statics.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Statics.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Statics.InitializeStatics(GraphicsDevice);

            Statics.Arial_8 = Content.Load<SpriteFont>("Arial_8");

            #region TabControl Test

            tabControl = new Controls.TabControl();

            Controls.Button a = new Controls.Button();
            a.Bounds = new Rectangle(30, 30, 40, 20);
            Controls.Label labela = new Controls.Label(a.Bounds, Statics.Arial_8, "Button A", Color.Red);
            a.ChildControl = labela;
            tabControl.tabs[0].Controls.Add(a);

            Controls.Button b = new Controls.Button();
            b.Bounds = new Rectangle(40, 40, 40, 20);
            Controls.Image image = new Controls.Image(Statics.SimpleTexture, b.Bounds, Color.Green);
            b.ChildControl = image;
            tabControl.tabs[1].Controls.Add(b);

            #endregion TabControl Test

            #region ListBox Test

            ////Create Listbox
            //listbox = new Controls.ListBox();
            ////formatting
            //listbox.Bounds = new Rectangle(100, 100, 200, 200);

            ////Adding Items
            //listbox.AddNewListBoxItem(Statics.SimpleTexture, "Listbox Item 1", Color.Blue);
            //listbox.AddNewListBoxItem(Statics.SimpleTexture, "Listbox Item 2", Color.Red);

            #endregion ListBox Test

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }


        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Statics.GameTime = gameTime;

            UpdateInputStates();

            //button Test
            //button.Update(gameTime);

            //tabControl Test
            tabControl.Update(gameTime);

            ////listbox Test
            //listbox.Update(gameTime);

            base.Update(gameTime);
        }

        private void UpdateInputStates()
        {
            Statics.PreviouseKeyboardState = Statics.CurrentKeyboardState;
            Statics.CurrentKeyboardState = Keyboard.GetState();

            Statics.PreviousMouseState = Statics.CurrentMouseState;
            Statics.CurrentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Statics.SpriteBatch.Begin();

            // tabControl Test
            tabControl.Draw(gameTime);

            ////listbox Test
            //listbox.Draw(gameTime);

            Statics.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
