using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomManager
{

    private int roomNumber;
    private Room currentRoom;

    public RoomManager()
    {
        roomNumber = 0;
        currentRoom = new Room(0);
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

        
    }
}

