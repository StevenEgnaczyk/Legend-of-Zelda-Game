using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class NextMapCommand : ICommand
{
    public RoomManager currentRoom;

    public NextMapCommand(RoomManager room)
    {
        currentRoom = room;
    }

    public void Execute()
    {
        currentRoom.nextRoom();
    }
}