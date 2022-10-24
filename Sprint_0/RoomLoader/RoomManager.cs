using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomManager
{
    private Link link;
    private int roomNumber;
    Room currentRoom;
    SpriteBatch spriteBatch;

    public RoomManager(SpriteBatch sb, Link link)
    {
        this.spriteBatch = sb;
        roomNumber = 2;
        this.link = link;
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
        
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

    }

    internal void nextRoom()
    {
        roomNumber++;
        if (roomNumber == 17)
        {
            roomNumber = 0;
        }
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
    }

    internal void prevRoom()
    {
        roomNumber--;
        if (roomNumber == -1)
        {
            roomNumber = 16;
        }
        currentRoom = new Room(roomNumber, spriteBatch, this.link);

    }

    public void Update(SpriteBatch spriteBatch)
    {
        currentRoom.Update(spriteBatch);
    }
}

