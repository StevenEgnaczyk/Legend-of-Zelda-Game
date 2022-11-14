using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class RoomManager
{
    private Link link;
    private int roomNumber;
    public Room currentRoom;

    SpriteBatch spriteBatch;
    public static int NUM_ROOMS = 18;
    private static int HUD_SIZE = 224;

    public Dictionary<int, List<IDoor>> doorMemory;
    public Dictionary<int, List<ITile>> tileMemory;
    public Dictionary<int, List<IEnemy>> enemyMemory;
    public Dictionary<int, List<IItem>> itemMemory;

    //This class calls a new room and manages the switching between different rooms
    public RoomManager(SpriteBatch sb, Link link)
    {
        this.spriteBatch = sb;
        roomNumber = 1;
        this.link = link;
        this.link.currentRoom = roomNumber;

        doorMemory = new Dictionary<int, List<IDoor>>();
        tileMemory = new Dictionary<int, List<ITile>>();
        enemyMemory = new Dictionary<int, List<IEnemy>>();
        itemMemory = new Dictionary<int, List<IItem>>();

        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
        
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

    }

    public void Update()
    {
        currentRoom.Update();
    }

    internal void loadRoom(int roomNumber)
    {
        link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
    }

    public void reset()
    {
        roomNumber = 1;
        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
    }

    public void drawBackground(SpriteBatch spriteBatch)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(roomNumber);
        Rectangle destRect = new(0, HUD_SIZE + ((176 - bgRect.Height) * 4), bgRect.Width * 4, bgRect.Height * 4);
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

    internal void saveRoomInfo()
    {
        int roomNum = currentRoom.getIndex();
        if (!doorMemory.ContainsKey(roomNum))
        {
            doorMemory.Add(roomNum, currentRoom.getDoors());
            tileMemory.Add(roomNum, currentRoom.getTiles());
            enemyMemory.Add(roomNum, currentRoom.getEnemies());
            itemMemory.Add(roomNum, currentRoom.getItems());
        }
    }
}

