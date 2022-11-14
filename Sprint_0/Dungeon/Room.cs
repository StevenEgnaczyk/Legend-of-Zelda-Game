using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;


public class Room
{

    RoomManager roomManager;

    private int currentRoomIndex;
    List<List<List<int>>> roomInformation;

    private EnemyManager enemyManager;
    private TileManager tileManager;
    private ItemManager itemManager;

    private Link link;

    public Room(int roomIndex, SpriteBatch spriteBatch, Link link, RoomManager roomManager)
    {
        this.currentRoomIndex = roomIndex;
        this.link = link;

        roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);

        enemyManager = new EnemyManager(spriteBatch);
        populateEnemies(roomInformation[2], spriteBatch);

        tileManager = new TileManager(spriteBatch);
        populateTiles(roomInformation[1]);

        itemManager = new ItemManager(spriteBatch);
        populateItems(roomInformation[3]);

        this.roomManager = roomManager;
    }

    private void populateItems(List<List<int>> itemInformation)
    {
        List<IItem> items = new List<IItem>();
        for (int row = 0; row < itemInformation.Count; row++)
        {
            for (int col = 0; col < itemInformation[row].Count; col++)
            {
                if (itemInformation[row][col] != 30)
                {
                    ItemManager.instance.getItemByIndex(itemManager, itemInformation[row][col], row, col);
                }
            }
        }
    }

    private void populateTiles(List<List<int>> tileInformation)
    {
        List<ITile> tiles = new List<ITile>();
        for (int row = 0; row < tileInformation.Count; row++)
        {
            for (int col = 0; col < tileInformation[row].Count; col++)
            {
                tileManager.addTile(TileManager.instance.getTileByIndex(tileInformation[row][col], row, col));
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
                if(enemyInformation[row][col] != 20)
                {
                    enemyManager.addEnemy(EnemyManager.instance.getEnemyByIndex(enemyInformation[row][col], row, col));
                }
            }
        }
    }

    internal void draw(SpriteBatch spriteBatch)
    {

        roomManager.drawBackground(spriteBatch, roomInformation[0]);
        tileManager.Draw(spriteBatch);
        enemyManager.Draw();
        itemManager.Draw(spriteBatch);

    }

    public void Update()
    {
        CollisionManager.instance.manageCollisions(link, enemyManager.enemiesList, tileManager.tileList, itemManager.itemList, link.inventory);
    }
}
