﻿using Microsoft.Xna.Framework;
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

        //Sprite for the text-field
        //private ISprite text;

        //Keyboard variables
        private KeyboardController _keyboardController;
        private KeyboardState _keyboardState;

        //Mouse variables
        private MouseController _mouseController;
        private MouseState _mouseState;

        //Integer to keep track of the last drawn sprite
        private int lastDrawn;

        //Initial Sprite
        private ChangeToNonAnimatedNonMovingCommand _changeToNonAnimatedNonMovingCommand;

        private DynamicTilesCommand _dynamicTilesCommand;

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
            //text = new TextSprite(Content);
            _keyboardController = new KeyboardController(Content);
            _dynamicTilesCommand = new DynamicTilesCommand(Content);
            _mouseController = new MouseController(Content);

            //Set last drawn to 1
            lastDrawn = 5;
        }

        protected override void LoadContent()
        {
            //Load initial Mario state
            
            //_changeToNonAnimatedNonMovingCommand = new ChangeToNonAnimatedNonMovingCommand(Content);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //_changeToNonAnimatedNonMovingCommand.drawSprite(_spriteBatch);
            //_dynamicTilesCommand.drawSprite(_spriteBatch);
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
            //text.Draw(_spriteBatch);

            //Process keyboard input
            _keyboardState = Keyboard.GetState();
            lastDrawn = _keyboardController.ProcessInput(_keyboardState.GetPressedKeys(), _spriteBatch, lastDrawn);

            //Process Mouse Input
            _mouseState = Mouse.GetState();
            lastDrawn = _mouseController.ProcessInput(_mouseState, _spriteBatch, lastDrawn);

            base.Draw(gameTime);
        }
    }
}