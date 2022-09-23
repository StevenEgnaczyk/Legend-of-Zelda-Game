using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Sprint_0
{
    public class Game1 : Game
    {
        //Set up graphics objects
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Link link;

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
            base.Initialize();
            _keyboardController = new KeyboardController(Content);
            _mouseController = new MouseController(Content);
            link = new Link();

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Process Keyboard Input
            _keyboardController.ProcessInput();

            //Process Mouse Input
            _mouseController.ProcessInput();

            link.Draw();

            base.Draw(gameTime);
        }
    }
}