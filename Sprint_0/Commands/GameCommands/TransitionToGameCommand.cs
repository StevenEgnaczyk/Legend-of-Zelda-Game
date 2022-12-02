using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class TransitionToGameCommmand : ICommand
{

    private Game1 theGame;

    public TransitionToGameCommmand(Game1 game)
    {
        this.theGame = game;
    }

    public void Execute()
    {
        //begin transition animation going from inventory to game
        theGame.currentGameState.changeToTransitioning();
        
    }
}
