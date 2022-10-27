using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class openInventoryCommand : ICommand
{

    private Game1 game;

    public openInventoryCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentGameState = new Sprint_0.GameStates.InventoryState(game);
        
    }
}
