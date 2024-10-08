using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class ChangeToWinScreenCommand : ICommand
{

    private Game1 game;

    public ChangeToWinScreenCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        //change game state to death
        game.currentGameState = new Sprint_0.GameStates.WinScreenState(game);
        //this.roomManager.reset();
    }
}