using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class LoadRoomCommand : ICommand
{
    public RoomManager roomManager;

    public LoadRoomCommand(RoomManager room)
    {
        roomManager = room;
    }

    public void Execute(int roomNumber)
    {
        //loads room into the manager
        roomManager.loadRoom(roomNumber);
    }

    public void Execute()
    {
        //Do Nothing
    }
}