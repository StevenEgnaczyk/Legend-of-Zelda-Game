using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Reflection;


public class DoorManager
{
    public List<IDoor> doorList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public static DoorManager instance = new DoorManager(sb);
    private static int HUD_SIZE = 224;

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

    public void addDoor(IDoor door)
    {
        doorList.Add(door);
    }

    public void removeDoor(IDoor door)
    {
        doorList.Remove(door);
    }

    public IDoor getDoorByIndex(int doorIndex, int row, int col)
    {
        switch (doorIndex)
        {
            case 12:
                return (new DoorTop(64 + (col * 64), HUD_SIZE + 64 + (64 * row), doorIndex));
            case 13:
                return (new DoorRight(64 + (col * 64), HUD_SIZE + 64 + (64 * row), doorIndex));
            case 14:
                return (new DoorBottom(64 + (col * 64), HUD_SIZE + 64 + (64 * row), doorIndex));
            case 15:
                return (new DoorLeft(64 + (col * 64), HUD_SIZE + 64 + (64 * row), doorIndex));
            default:
                return (new DoorTop(64 + (col * 64), HUD_SIZE + 64 + (64 * row), doorIndex));

        }
    }

    public void DrawDoors(SpriteBatch spriteBatch)
    {
        foreach (IDoor door in doorList)
        {
            door.Draw(spriteBatch);
        }
    }
}