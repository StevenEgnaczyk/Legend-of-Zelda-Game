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
    private List<Item> items;

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

    private List<Item> populateItems(List<List<int>> itemInformation)
    {

        List<Item> items = new List<Item>();
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
                    case 1:
                        tiles.Add(new walkTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 2:
                        tiles.Add(new BrickTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 3:
                        tiles.Add(new BlueSandTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 4:
                        tiles.Add(new WaterTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 5:
                        tiles.Add(new StatueRightTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 6:
                        tiles.Add(new StatueLeftTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 7:
                        tiles.Add(new BlackTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 8:
                        tiles.Add(new StairTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 9:
                        tiles.Add(new PushTile(128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    default:
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
                    case 11:
                        enemies.Add(new Keese(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 12:
                        enemies.Add(new Stalfos(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 13:
                        enemies.Add(new Goriya(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 14:
                        enemies.Add(new Wallmaster(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 15:
                        enemies.Add(new Aquamentus(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 16:
                        enemies.Add(new BladeTrap(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
                        break;
                    case 17:
                        enemies.Add(new Gel(spriteBatch, enemyManager, 128 + (col * 64), 320 + 128 + (64 * row)));
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

    public void drawBlockLine(SpriteBatch spriteBatch, List<int> list, int rowNum)
    {
        Texture2D blockSprites = Texture2DStorage.GetDungeonTileset();
        Rectangle blockRect;
        Rectangle destRect;


        for (int i = 0; i < list.Count; i++)
        {
            blockRect = Texture2DStorage.getBlockRect(list[i]);
            destRect = new Rectangle(128 + (i * 64), 320 + 128  + (64 * rowNum), 64, 64);
            spriteBatch.Draw(blockSprites, destRect, blockRect, Color.White);


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
