﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;


public class Room
{

    private int currentRoomIndex;
    List<List<List<int>>> roomInformation;

    //Managers for room entities
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

        //If the room has been previously opened
        if (roomManager.doorMemory.ContainsKey(currentRoomIndex))
        {

            roomManager.setBackground(roomManager.backgroundMemory[currentRoomIndex]);

            //Load in the room information from memory
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

            //Load in the room information from the correct file
            roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);

            roomManager.setBackground(roomInformation[0][0][0]);

            doorManager = new DoorManager(spriteBatch);
            populateDoors(roomInformation[1]);

            tileManager = new TileManager(spriteBatch);
            populateTiles(roomInformation[2]);

            enemyManager = new EnemyManager(spriteBatch);
            populateEnemies(roomInformation[3], spriteBatch);

            itemManager = new ItemManager(this, spriteBatch);
            populateItems(roomInformation[4]);
        }

    }

    //Populate the item manager with items
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

    //Populate the tile manager with tiles
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

    //Populate the door manager with doors
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

    //populate the enemy manager with enemies
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

    //Draw all entities
    internal void draw(SpriteBatch spriteBatch)

    {
        roomManager.drawBackground(spriteBatch);
        doorManager.DrawDoors(spriteBatch);
        tileManager.DrawTiles(spriteBatch);
        enemyManager.Draw();
        itemManager.Draw(spriteBatch);

    }

    //Update all relevant entities
    public void Update()
    {
        doorManager.Update();
        enemyManager.Update();

        //Manage collisions
        CollisionManager.instance.manageCollisions(link, doorManager.doorList, enemyManager.enemiesList, tileManager.tileList, tileManager.pushBlockList, itemManager.itemList, link.inventory);
    }

    /* Unlock a particular door */
    internal void unlockDoor(int v)
    {
        if (v > 0)
        {
            doorManager.doorList[v].Unlock();
        }
    }

    /* Getters and Setters */
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
}
