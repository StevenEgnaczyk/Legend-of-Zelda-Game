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
        private Item item;
        private Tile tile;
        private IEnemy enemy;

        private RoomManager roomManager;

        //Keyboard variables
        private KeyboardController _keyboardController;

        //private int track;

        public Game1()
        {

            //Initialize objects
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 784;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //lastDrawn = 5;
            
            link = new Link();
            oldMan1 = new OldMan();
            item = new Item();
            tile = new Tile();
            enemy = new Enemy(_spriteBatch);
            roomManager = new RoomManager();

            
            _keyboardController = new KeyboardController(Content, link, item, tile, enemy);
            //_mouseController = new MouseController(Content);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            //Create the spriteBatch
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2DStorage.LoadAllTextures(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            link.Update();

            //Process Keyboard Input
            _keyboardController.ProcessInput();

        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();
            link.Draw(_spriteBatch);
            link.Update();
            oldMan1.Draw(_spriteBatch);
            item.Draw(_spriteBatch);
            tile.Draw(_spriteBatch);
            enemy.draw(_spriteBatch);
            roomManager.drawRoom(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}