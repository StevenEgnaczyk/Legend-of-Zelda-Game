using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class PuzzleManager
{
    private Link link;
    private int roomNumber;
    public Room currentRoom;

    //This class calls a new room and manages the switching between different rooms
    public PuzzleManager(Link link, Room room)
    {
        this.currentRoom = room;
        this.link = link;
        
    }

    public void managePuzzles()
    {
        currentRoom.getDoorManager().unlockDoor(3);

    }
}

