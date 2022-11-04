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
        roomNumber = 0;
        this.link = link;
        this.link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
        
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

    }

    internal void nextRoom()
    {
        //increments room number index, if over max room number set to initial room 
        roomNumber++;
        if (roomNumber > NUM_ROOMS)
        {
            roomNumber = 0;
        }
        link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link);
    }

    internal void prevRoom()
    {
        //decrements room number index, if over min room number set to last room
        roomNumber--;
        if (roomNumber == -1)
        {
            roomNumber = 17;
        }
        link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link);

    }

    public void Update()
    {
        currentRoom.Update();
    }
}

