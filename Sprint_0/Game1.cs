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
        private EnemyManager enemyManager;
        private TileManager tileManager;
        private ItemManager itemManager;
        private CollisionManager collisionManager;

        //Keyboard variables
        private IController keyboardController;
        private IController mouseController;

        //private int track;

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
            roomManager = new RoomManager();
            enemyManager = new EnemyManager(_spriteBatch);
            tileManager = new TileManager(_spriteBatch);
            itemManager = new ItemManager();
            collisionManager = new CollisionManager(); 

            link = new Link();
            oldMan1 = new OldMan();
            item = new Item(itemManager);
            tile = new Tile(tileManager);
            //enemy = new Enemy(_spriteBatch,enemyManager);
           
            

            
            keyboardController = new KeyboardController(Content, link, item, tile, enemy);
            mouseController = new MouseController(Content, roomManager);
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
            enemyManager.Update();
            itemManager.Update();


            //Collision Detection and response for each game object
            collisionManager.manageCollisions(link, enemyManager.enemiesList, tileManager.tileList, itemManager.itemList);

            //Process Keyboard Input
            keyboardController.ProcessInput();
            mouseController.ProcessInput();

        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin();
            roomManager.drawRoom(_spriteBatch);
            enemyManager.Draw();
            itemManager.Draw();
            tileManager.Draw();
            link.Draw(_spriteBatch);
            link.Update();
            oldMan1.Draw(_spriteBatch);
            item.Draw(_spriteBatch);
            tile.Draw(_spriteBatch);
            enemy.draw(_spriteBatch);
            
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}