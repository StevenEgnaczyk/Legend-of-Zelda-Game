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
    public static int NUM_ROOMS = 17;

    //This class calls a new room and manages the switching between different rooms
    public RoomManager(SpriteBatch sb, Link link)
    {
        this.spriteBatch = sb;
        roomNumber = 1;
        this.link = link;
        this.link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
        
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
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
    }

    public void reset()
    {
        currentRoom = new Room(0, spriteBatch, this.link);
    }
}

