using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class PrevMapCommand : ICommand
{
    public RoomManager currentRoom;

    public PrevMapCommand(RoomManager room)
    {
        currentRoom = room;
    }

    public void Execute()
    {
        currentRoom.prevRoom();
    }
}