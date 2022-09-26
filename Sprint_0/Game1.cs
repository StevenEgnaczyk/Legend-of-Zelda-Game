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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Link link;
        private OldMan oldMan1;
        private Flame flame;
        private Bomb bomb;

        //Keyboard variables
        private KeyboardController _keyboardController;
        private KeyboardState _keyboardState;

        //Mouse variables
        private MouseController _mouseController;
        private MouseState _mouseState;

        //Integer to keep track of the last drawn sprite
        private int lastDrawn;

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
            _mouseController = new MouseController(Content);

            //Set last drawn to 1
            lastDrawn = 1;
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

            _spriteBatch.Begin();
            link.Draw(_spriteBatch);
            oldMan1.Draw(_spriteBatch);
            flame.Draw(_spriteBatch);
            bomb.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}