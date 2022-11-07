using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

public class ChangeToGameplayStateCommand : ICommand
{

    private Game1 game;

    public ChangeToGameplayStateCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentGameState = new Sprint_0.GameStates.GameplayState(game);
        game.link.inventory.secondaryWeaponManager.SetSecondaryWeapon(game.link.inventory.inventoryManager.getSelectedSecondaryWeaponIndex());
        
    }
}
