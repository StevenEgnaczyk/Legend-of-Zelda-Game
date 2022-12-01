using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

public class DoorManager
{
    public List<IDoor> doorList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public static DoorManager instance = new DoorManager(sb);

    public static DoorManager Instance
    {
        get
        {
            return instance;
        }
    }


    public DoorManager(SpriteBatch spriteBatch)
    {
        doorList = new List<IDoor>();
        sb = spriteBatch;
    }

    //add door to door list
    public void addDoor(IDoor door)
    {
        doorList.Add(door);
    }

    //remove door from door list
    public void removeDoor(IDoor door)
    {
        doorList.Remove(door);
    }

    //changes door list to reflect the unlocking of a door
    public void unlockDoor(int doorIndex)
    {
        Rectangle doorRect = RoomRectStorage.getDoorDestinationRect(doorIndex);
        this.doorList[doorIndex] = new DoorLeft(doorRect.X, doorRect.Y, doorIndex);
    }

    //gets correct door from an integer index
    public IDoor getDoorByIndex(int doorIndex, int row, int col)
    {

        Rectangle doorRect = RoomRectStorage.getDoorDestinationRect(col);
        switch (col)
        {
            case 0:
                return (new DoorTop(doorRect.X, doorRect.Y, doorIndex));
            case 1:
                return (new DoorRight(doorRect.X, doorRect.Y, doorIndex));
            case 2:
                return (new DoorBottom(doorRect.X, doorRect.Y, doorIndex));
            case 3:
                return (new DoorLeft(doorRect.X, doorRect.Y, doorIndex));
            default:
                return (new DoorTop(doorRect.X, doorRect.Y, doorIndex));

        }
    }

    //draws all doors in doorlist
    public void DrawDoors(SpriteBatch spriteBatch)
    {
        foreach (IDoor door in doorList)
        {
            door.Draw(spriteBatch);
        }
    }

    //updates all doors in doorlist
    public void Update()
    {
        foreach (IDoor door in doorList)
        {
            door.Update();
        }
    }
}