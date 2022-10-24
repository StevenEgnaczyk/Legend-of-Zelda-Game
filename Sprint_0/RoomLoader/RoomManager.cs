using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomManager
{

    private int roomNumber;
    Room currentRoom;
    SpriteBatch spriteBatch;

    //This class calls a new room and manages the switching between different rooms
    public RoomManager(SpriteBatch sb)
    {
        this.spriteBatch = sb;
        roomNumber = 2;
        currentRoom = new Room(roomNumber, spriteBatch);
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

    }

    internal void nextRoom()
    {
        //increments room number index, if over max room number set to initial room 
        roomNumber++;
        if (roomNumber == 17)
        {
            roomNumber = 0;
        }
        currentRoom = new Room(roomNumber, spriteBatch);
    }

    internal void prevRoom()
    {
        //decrements room number index, if over min room number set to last room
        roomNumber--;
        if (roomNumber == -1)
        {
            roomNumber = 16;
        }
        currentRoom = new Room(roomNumber, spriteBatch);

    }

    public void Update(SpriteBatch spriteBatch)
    {
        currentRoom.Update(spriteBatch);
    }
}

