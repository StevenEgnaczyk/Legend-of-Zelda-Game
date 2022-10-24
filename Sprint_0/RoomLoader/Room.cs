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

    public Room(int roomIndex, SpriteBatch spriteBatch)
    {
        this.currentRoomIndex = roomIndex;
        roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);
        enemyManager = new EnemyManager(spriteBatch);
        enemies = populateEnemies(roomInformation[2], spriteBatch);

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
                        enemies.Add(new Keese(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 12:
                        enemies.Add(new Stalfos(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 13:
                        enemies.Add(new Goriya(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 14:
                        enemies.Add(new Wallmaster(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 15:
                        enemies.Add(new Aquamentus(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 16:
                        enemies.Add(new BladeTrap(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
                        break;
                    case 17:
                        enemies.Add(new Gel(spriteBatch, enemyManager, 128 + (row * 64), (320 + 128 + (64 * col))));
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

        drawBlocks(spriteBatch, roomInformation[1]);
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

    public void drawEnemies(SpriteBatch spriteBatch, List<List<int>> enemyInformation)
    {
        for (int row = 0; row < enemyInformation.Count; row++)
        {
            for (int col = 0; col < enemyInformation[row].Count; col++)
            {
                
            }
        }
    }

    public void drawBlocks(SpriteBatch spriteBatch, List<List<int>> roomInformation)
    {
        for (int i = 0; i < roomInformation.Count; i++)
        {
            drawBlockLine(spriteBatch, roomInformation[i], i);
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
    }
}
