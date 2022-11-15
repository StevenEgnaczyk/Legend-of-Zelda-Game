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

        //Set up link
        public Link link;

        //Set up managers
        public RoomManager roomManager;
        public CollisionManager collisionManager;
        public HUDManager HUD;

        //Keyboard variables
        public IController keyboardController;
        public IController mouseController;

        //Game State
        public IState currentGameState;

        public Game1()
        {
            //Initialize objects
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 1024;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {

            //Set up game variables that are needed
            spriteBatch = new SpriteBatch(GraphicsDevice);
            collisionManager = new CollisionManager(this);
            link = new Link(spriteBatch);
            roomManager = new RoomManager(spriteBatch, link, 1);
            HUD = new HUDManager(link, link.inventory);
            currentGameState = new StartupScreenState(this);
            keyboardController = new KeyboardController(this, Content, link);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            //Load all content
            AudioStorage.LoadAllSounds(Content);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(AudioStorage.GetSong());
            Texture2DStorage.LoadAllTextures(Content);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            //Update the game
            base.Update(gameTime);
            currentGameState.Update();

        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw the game
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            currentGameState.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}