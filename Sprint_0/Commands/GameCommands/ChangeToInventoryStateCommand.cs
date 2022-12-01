using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class ChangeToInventoryStateCommand : ICommand
{

    private Game1 theGame;

    public ChangeToInventoryStateCommand(Game1 game)
    {
        this.theGame = game;
    }

    public void Execute()
    {
        //change current game state to inventory state
        theGame.currentGameState = new Sprint_0.GameStates.InventoryState(theGame);
        
    }
}
