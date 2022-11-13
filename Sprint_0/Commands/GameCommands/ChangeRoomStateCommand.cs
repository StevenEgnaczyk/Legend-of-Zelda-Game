using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class ChangeRoomStateCommand : ICommand
{

    private Game1 theGame;

    public ChangeRoomStateCommand(Game1 game)
    {
        this.theGame = game;
    }

    public void Execute()
    {
        
        
    }

    internal void Execute(Link link, int roomToTeleportTo)
    {
        theGame.currentGameState = new Sprint_0.GameStates.RoomTransitionState(theGame, roomToTeleportTo);
    }
}
