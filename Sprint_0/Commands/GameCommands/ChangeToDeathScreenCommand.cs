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
        game.currentGameState = new Sprint_0.GameStates.DeathScreenState(game);
    }
}