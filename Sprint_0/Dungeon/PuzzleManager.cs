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

    //Manage puzzles
    public void managePuzzles()
    {
        int currentRoom = manager.currentRoom.getIndex();
        switch (currentRoom)
        {
            case 1:
                //Open the door if you have 5 DaTokens
                manager.currentRoom.unlockDoor(2);
                break;

            case 11:

                //Open the door in the push block room
                manager.currentRoom.unlockDoor(3);
                break;
            case 6:

                //Open the door after all the enemies have been killed
                manager.currentRoom.unlockDoor(1);
                break;
                
            case 14:

                //Open the door after all the enemies have been killed
                manager.currentRoom.unlockDoor(1);
                break;
        }
        

    }
}

