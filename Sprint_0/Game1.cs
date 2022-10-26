using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.HUD;
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
        private IItem map;
        private RoomManager roomManager;
        private CollisionManager collisionManager;
        private HUDManager HUD;

        //Keyboard variables
        private IController keyboardController;
        private IController mouseController;

        public Game1()
        {

            //Initialize objects
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 1024;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //lastDrawn = 5;

            /* 
             * Make spriteBatch not a property for items, instead pass it through
             * ItemManager (less instances of spritebatch) - EH
             */
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            collisionManager = new CollisionManager(); 
            link = new Link();
            HUD = new HUDManager(link, link.inventory);
            map = new Map(950, 350);
            roomManager = new RoomManager(_spriteBatch, link);

            keyboardController = new KeyboardController(Content, link);
            mouseController = new MouseController(Content, roomManager);


            base.Initialize();

        }

        protected override void LoadContent()
        {
            //Create the spriteBatch
            
            Texture2DStorage.LoadAllTextures(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            link.Update();

            //Process Keyboard Input
            keyboardController.ProcessInput();
            mouseController.ProcessInput();

            link.Update();
            map.Update();


        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            roomManager.drawRoom(_spriteBatch);

            link.Draw(_spriteBatch);
            map.Draw(_spriteBatch);
            HUD.Draw(_spriteBatch);
            roomManager.Update(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}