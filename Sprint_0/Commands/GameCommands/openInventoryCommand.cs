using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class OpenInventoryCommand : ICommand
{

    private Game1 theGame;

    public OpenInventoryCommand(Game1 game)
    {
        this.theGame = game;
    }

    public void Execute()
    {
        theGame.currentGameState = new Sprint_0.GameStates.InventoryState(theGame);
        
    }
}
