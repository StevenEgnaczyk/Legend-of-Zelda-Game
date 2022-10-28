using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class OpenGameCommand : ICommand
{

    private Game1 game;

    public OpenGameCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentGameState = new Sprint_0.GameStates.GameplayState(game);
        
    }
}
