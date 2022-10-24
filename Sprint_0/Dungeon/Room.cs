using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;


public class Room
{
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
        enemies = populateEnemies(roomInformation[2], spriteBatch);

        tileManager = new TileManager(spriteBatch);
        tiles = populateTiles(roomInformation[1]);

        itemManager = new ItemManager();
        items = populateItems(roomInformation[2]);


    }

    private List<IItem> populateItems(List<List<int>> itemInformation)
    {

        List<IItem> items = new List<IItem>();
        for (int row = 0; row < itemInformation.Count; row++)
        {
            for (int col = 0; col < itemInformation[row].Count; col++)
            {

                switch (itemInformation[row][col])
                {

                }
            }
        }

        return items;
    }

    private List<ITile> populateTiles(List<List<int>> itemInformation)
    {
        List<ITile> tiles = new List<ITile>();
        for (int row = 0; row < itemInformation.Count; row++)
        {
            for (int col = 0; col < itemInformation[row].Count; col++)
            {
                switch (itemInformation[row][col])
                {
                    case 0:
                        tiles.Add(new InvisibleTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 1:
                        tiles.Add(new walkTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 2:
                        tiles.Add(new BrickTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 3:
                        tiles.Add(new BlueSandTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 4:
                        tiles.Add(new WaterTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 5:
                        tiles.Add(new StatueRightTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 6:
                        tiles.Add(new StatueLeftTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 7:
                        tiles.Add(new BlackTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 8:
                        tiles.Add(new StairTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 9:
                        tiles.Add(new PushTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    default:
                        tiles.Add(new InvisibleTile(64 + (col * 64), 320 + 64 + (64 * row)));
                        break;

                }
            }
        }

        return tiles;
    }

    private List<IEnemy> populateEnemies(List<List<int>> enemyInformation, SpriteBatch spriteBatch)
    {
        List<IEnemy> enemies = new List<IEnemy>();  
        for (int row = 0; row < enemyInformation.Count; row++)
        {
                for (int col = 0; col < enemyInformation[row].Count; col++)
                {

                switch (enemyInformation[row][col])
                {
                    case 21:
                        enemies.Add(new Keese(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 22:
                        enemies.Add(new Stalfos(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 23:
                        enemies.Add(new Goriya(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 24:
                        enemies.Add(new Wallmaster(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 25:
                        enemies.Add(new Aquamentus(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 26:
                        enemies.Add(new BladeTrap(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    case 27:
                        enemies.Add(new Gel(spriteBatch, enemyManager, 64 + (col * 64), 320 + 64 + (64 * row)));
                        break;
                    default:

                        break;

                }


                }
            }
        return enemies;
    }

    internal void draw(SpriteBatch spriteBatch)
    {

        drawBlocks(spriteBatch, tiles);
        drawBackground(spriteBatch, roomInformation[0]);

    }

    public void drawBackground(SpriteBatch spriteBatch, List<List<int>> backgroundInformation)
    {
        drawDoors(spriteBatch, backgroundInformation[0]);
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(0);
        Rectangle destRect = new Rectangle(0, 320, bgRect.Width * 4, bgRect.Height * 4);
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

    public void drawBlocks(SpriteBatch spriteBatch, List<ITile> tiles)
    {
        foreach (ITile t in tiles) {
            t.Draw(spriteBatch);
        }
    }

    public void Update(SpriteBatch spriteBatch)
    {
        foreach (IEnemy enemy in enemies)
        {
            enemy.draw(spriteBatch);
            enemy.update();
        }

        collisionManager.manageCollisions(link, enemies, tiles, items);
    }
}
