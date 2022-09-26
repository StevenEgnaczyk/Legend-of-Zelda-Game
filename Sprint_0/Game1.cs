using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sprint_0
{
    public class Game1 : Game
    {
        //Set up graphics objects
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Link link;
        private OldMan oldMan1;
        private Flame flame;
        private Bomb bomb;
        private Item item;

        //Keyboard variables
        private KeyboardController _keyboardController;

        //Mouse variables
        private MouseController _mouseController;

        public Game1()
        {

            //Initialize objects
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //Initialize text, keyboard, and mouse
            link = new Link();
            oldMan1 = new OldMan();
            flame = new Flame();
            bomb = new Bomb();
            
            _keyboardController = new KeyboardController(Content, link);
            item = new Item();
            
            _keyboardController = new KeyboardController(Content, link, item);
            _mouseController = new MouseController(Content);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            //Create the spriteBatch
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2DStorage.LoadAllTextures(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            //Clear the background and draw the text
            GraphicsDevice.Clear(Color.DarkGray);

            //Process Keyboard Input
            _keyboardController.ProcessInput();

            //Process Mouse Input
            _mouseController.ProcessInput();

            _spriteBatch.Begin();
            link.Draw(_spriteBatch);
            oldMan1.Draw(_spriteBatch);
            flame.Draw(_spriteBatch);
            bomb.Draw(_spriteBatch);
            item.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}