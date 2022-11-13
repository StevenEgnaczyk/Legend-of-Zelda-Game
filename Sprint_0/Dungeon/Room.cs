using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;


public class Room
{

    private static int HUD_SIZE = 224;
    private int currentRoomIndex;
    List<List<List<int>>> roomInformation;

    private EnemyManager enemyManager;
    private List<IEnemy> enemies;

    private TileManager tileManager;
    private List<ITile> tiles;

    private ItemManager itemManager;
    private List<IItem> items;

    private Link link;

    CollisionManager collisionManager;

    public Room(int roomIndex, SpriteBatch spriteBatch, Link link)
    {
        this.currentRoomIndex = roomIndex;
        this.link = link;

        collisionManager = new CollisionManager();

        roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);

        enemyManager = new EnemyManager(spriteBatch);
        populateEnemies(roomInformation[2], spriteBatch);

        tileManager = new TileManager(spriteBatch);
        populateTiles(roomInformation[1]);

        itemManager = new ItemManager(spriteBatch);
        populateItems(roomInformation[3]);


    }

    private void populateItems(List<List<int>> itemInformation)
    {
        List<IItem> items = new List<IItem>();
        for (int row = 0; row < itemInformation.Count; row++)
        {
            for (int col = 0; col < itemInformation[row].Count; col++)
            {
                switch (itemInformation[row][col])
                {
                    case 31:
                        new Candle(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    case 32:
                        new WoodenBoomerang(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    case 33:
                        new Bow(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    case 34:
                        new Bomb(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    case 35:
                        new Compass(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    case 36:
                        new Map(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                        break;
                    default:

                        break;
                }
            }
        }
    }

    private void populateTiles(List<List<int>> itemInformation)
    {
        List<ITile> tiles = new List<ITile>();
        for (int row = 0; row < itemInformation.Count; row++)
        {
            for (int col = 0; col < itemInformation[row].Count; col++)
            {
                tileManager.addTile(TileManager.instance.getTileByIndex(itemInformation[row][col], row, col));
            }
        }
    }

    private void populateEnemies(List<List<int>> enemyInformation, SpriteBatch spriteBatch)
    {
        List<IEnemy> enemies = new List<IEnemy>();  
        for (int row = 0; row < enemyInformation.Count; row++)
        {
                for (int col = 0; col < enemyInformation[row].Count; col++)
                {

                switch (enemyInformation[row][col])
                {
                    case 21:
                        enemyManager.addEnemy(new Keese(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 22:
                        enemyManager.addEnemy(new Stalfos(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 23:
                        enemyManager.addEnemy(new Goriya(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 24:
                        enemyManager.addEnemy(new Wallmaster(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 25:
                        enemyManager.addEnemy(new Aquamentus(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 26:
                        enemyManager.addEnemy(new BladeTrap(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 27:
                        enemyManager.addEnemy(new Gel(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 28:
                        enemyManager.addEnemy(new OldMan(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    case 29:
                        enemyManager.addEnemy(new Flame(spriteBatch, enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row)));
                        break;
                    default:

                        break;

                }


                }
            }
    }

    internal void draw(SpriteBatch spriteBatch)
    {

        drawBackground(spriteBatch, roomInformation[0]);
        tileManager.Draw(spriteBatch);
        enemyManager.Draw();
        itemManager.Draw(spriteBatch);

    }

    public void drawBackground(SpriteBatch spriteBatch, List<List<int>> backgroundInformation)
    {
        drawDoors(spriteBatch, backgroundInformation[0]);
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(0);
        Rectangle destRect = new Rectangle(0, HUD_SIZE, bgRect.Width * 4, bgRect.Height * 4);
        spriteBatch.Draw(dungeonTiles, destRect, bgRect, Color.White);

    }

    public void drawDoors(SpriteBatch spriteBatch, List<int> doorInformation)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();

        for (int i = 0; i < 4; i++)
        {

            Rectangle doorSourceRect = RoomRectStorage.getDoorSourceRect(doorInformation[i], i);
            Rectangle doorDestinationRect = RoomRectStorage.getDoorDestinationRect(i);
            spriteBatch.Draw(dungeonTiles, doorDestinationRect, doorSourceRect, Color.White);
        }

    }

    public void drawDoor(SpriteBatch spriteBatch, int newDoorTexture, int doorIndex)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle doorSourceRect = RoomRectStorage.getDoorSourceRect(newDoorTexture, doorIndex);
        Rectangle doorDestinationRect = RoomRectStorage.getDoorDestinationRect(0);
        spriteBatch.Draw(dungeonTiles, doorDestinationRect, doorSourceRect, Color.White);

    }

    public void drawBlocks(SpriteBatch spriteBatch, List<ITile> tiles)
    {
        foreach (ITile t in tiles) {
            t.Draw(spriteBatch);
        }
    }

    public void Update()
    {
        collisionManager.manageCollisions(link, enemyManager.enemiesList, tileManager.tileList, itemManager.itemList, link.inventory);
    }
}
