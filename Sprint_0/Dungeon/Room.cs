using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;


public class Room
{

    private int currentRoomIndex;
    List<List<List<int>>> roomInformation;

    private DoorManager doorManager;
    private EnemyManager enemyManager;
    private TileManager tileManager;
    private ItemManager itemManager;


    private Link link;

    RoomManager roomManager;

    public Room(int roomIndex, SpriteBatch spriteBatch, Link link, RoomManager roomManager)
    {
        this.currentRoomIndex = roomIndex;
        this.link = link;
        this.roomManager = roomManager;

        if (roomManager.doorMemory.ContainsKey(currentRoomIndex))
        {

            doorManager = new DoorManager(spriteBatch);
            doorManager.doorList = roomManager.doorMemory[currentRoomIndex];

            enemyManager = new EnemyManager(spriteBatch);
            enemyManager.enemiesList = roomManager.enemyMemory[currentRoomIndex];

            tileManager = new TileManager(spriteBatch);
            tileManager.tileList = roomManager.tileMemory[currentRoomIndex];

            itemManager = new ItemManager(this, spriteBatch);
            itemManager.itemList = roomManager.itemMemory[currentRoomIndex];


        }
        else
        {
            roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);

            doorManager = new DoorManager(spriteBatch);
            populateDoors(roomInformation[0]);

            tileManager = new TileManager(spriteBatch);
            populateTiles(roomInformation[1]);

            enemyManager = new EnemyManager(spriteBatch);
            populateEnemies(roomInformation[2], spriteBatch);

            itemManager = new ItemManager(this, spriteBatch);
            populateItems(roomInformation[3]);
        }

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

    private void populateDoors(List<List<int>> doorInformation)
    {
        for (int row = 0; row < doorInformation.Count; row++)
        {
            for (int col = 0; col < doorInformation[row].Count; col++)
            {

                doorManager.addDoor(DoorManager.instance.getDoorByIndex(doorInformation[row][col], row, col));
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
                    EnemyManager.instance.getEnemyByIndex(enemyManager, enemyInformation[row][col], row, col);
                }
            }
        }
    }

    internal void draw(SpriteBatch spriteBatch)

    {
        roomManager.drawBackground(spriteBatch);
        doorManager.DrawDoors(spriteBatch);
        tileManager.DrawTiles(spriteBatch);
        enemyManager.Draw();
        itemManager.Draw(spriteBatch);

    }

    public void Update()
    {
        doorManager.Update();
        enemyManager.Update();
        CollisionManager.instance.manageCollisions(link, doorManager.doorList, enemyManager.enemiesList, tileManager.tileList, tileManager.pushBlockList, itemManager.itemList, link.inventory);
    }

    internal int getIndex()
    {
        return currentRoomIndex;
    }

    public List<IDoor> getDoors()
    {
        return doorManager.doorList;
    }

    public List<ITile> getTiles()
    {
        return tileManager.tileList;
    }

    public List<IEnemy> getEnemies()
    {
        return enemyManager.enemiesList;
    }

    public List<IItem> getItems()
    {
        return itemManager.itemList;
    }

    public ItemManager getItemManager()
    {
        return itemManager;
    }

    public DoorManager getDoorManager()
    {
        return this.doorManager;
    }

    internal void unlockDoor(int v)
    {
        doorManager.doorList[v].Unlock();
    }
}
