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
        //change current game state to the gameplay state from one of the screen states
        game.currentGameState = new Sprint_0.GameStates.GameplayState(game);
        //change selected secondary weapon to the one selected from the inventory while in inventory state
        game.link.inventory.secondaryWeaponManager.SetSecondaryWeapon(game.link.inventory.inventoryManager.getSelectedSecondaryWeaponIndex());
        
    }
}
