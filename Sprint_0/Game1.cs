using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sprint_0.GameStates;
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
        public SpriteBatch spriteBatch;

        public Link link;
        public IItem map;

        public RoomManager roomManager;
        public CollisionManager collisionManager;
        public Inventory inventoryManager;
        public HUDManager HUD;


        //Keyboard variables
        public IController keyboardController;
        public IController mouseController;

        public IState currentGameState;

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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            collisionManager = new CollisionManager(this);
            link = new Link(spriteBatch);
            roomManager = new RoomManager(spriteBatch, link);
            
            HUD = new HUDManager(link, link.inventory);
            currentGameState = new StartupScreenState(this);

            keyboardController = new KeyboardController(this, Content, link);
            mouseController = new MouseController(Content, roomManager);


            base.Initialize();

        }

        protected override void LoadContent()
        {
            //Create the spriteBatch
            AudioStorage.LoadAllSounds(Content);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(AudioStorage.GetSong());
            Texture2DStorage.LoadAllTextures(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentGameState.Update();

        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            currentGameState.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}