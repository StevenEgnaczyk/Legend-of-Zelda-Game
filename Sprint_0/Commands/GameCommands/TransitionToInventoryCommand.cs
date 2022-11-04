using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class TransitionToInventoryCommand : ICommand
{

    private Game1 theGame;

    public TransitionToInventoryCommand(Game1 game)
    {
        this.theGame = game;
    }

    public void Execute()
    {
        theGame.currentGameState.changeToTransitioning();
        
    }
}
