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
    public static RoomManager manager;
    public static PuzzleManager instance = new PuzzleManager(manager);


    //This class calls a new room and manages the switching between different rooms
    public PuzzleManager(RoomManager roomManager)
    {
        manager = roomManager;
        
    }

    public void managePuzzles()
    {
        int currentRoom = manager.currentRoom.getIndex();
        switch (currentRoom)
        {
            case 11:
                manager.currentRoom.unlockDoor(3);
                break;
            case 6:
                manager.currentRoom.unlockDoor(1);
                break;
        }
        

    }
}

