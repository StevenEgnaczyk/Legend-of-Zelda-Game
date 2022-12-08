using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class ChangeToDeathScreenCommand : ICommand
{

    private Game1 game;

    public ChangeToDeathScreenCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        //change game state to death
        game.currentGameState = new Sprint_0.GameStates.DeathScreenState(game);
        //this.roomManager.reset();
    }
}