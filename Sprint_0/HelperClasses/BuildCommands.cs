using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BuildCommands
{
    public Dictionary<Keys, ICommand> gameplayControllerMappings;
    public Dictionary<Keys, ICommand> inventoryControllerMappings;

    public ICommand _quitCommand;
    public ICommand turnPlayerLeftCommand;
    public ICommand turnPlayerRightCommand;
    public ICommand turnPlayerUpCommand;
    public ICommand turnPlayerDownCommand;

    public ICommand usePrimaryWeaponCommand;
    public ICommand useSecondaryWeaponCommand;

    public ICommand openInventoryCommand;
    public ICommand openGameCommand;

    public ICommand dieCommand;

    public ICommand cycleEnemyNextCommand;
    public ICommand cycleEnemyPreviousCommand;

    public ICommand cycleItemNextCommand;
    public ICommand cycleItemPrevCommand;
    public ICommand _dynamicTilesCommand;
    public ICommand _dynamicTilesCommandPrev;
    public ICommand resetCommand;

    public Keys[] state;

    public BuildCommands(Link linkPlayer, Game1 game)
    {
        gameplayControllerMappings = new Dictionary<Keys, ICommand>();
        inventoryControllerMappings = new Dictionary<Keys, ICommand>();

        _quitCommand = new QuitCommand();
        resetCommand = new ResetCommand(linkPlayer);
        turnPlayerLeftCommand = new TurnPlayerLeftCommand(linkPlayer);
        turnPlayerRightCommand = new TurnPlayerRightCommand(linkPlayer);
        turnPlayerUpCommand = new TurnPlayerUpCommand(linkPlayer);
        turnPlayerDownCommand = new TurnPlayerDownCommand(linkPlayer);

        usePrimaryWeaponCommand = new UsePrimaryWeaponCommand(linkPlayer);
        useSecondaryWeaponCommand = new UseSecondaryWeaponCommand(linkPlayer);

        openInventoryCommand = new OpenInventoryCommand(game);
        openGameCommand = new OpenGameCommand(game);

        dieCommand = new DieCommand(linkPlayer);

        RegisterGameplayCommand(Keys.D0, _quitCommand);
        RegisterGameplayCommand(Keys.NumPad0, _quitCommand);
        RegisterGameplayCommand(Keys.Q, _quitCommand);
        RegisterGameplayCommand(Keys.R, resetCommand);

        RegisterGameplayCommand(Keys.Left, turnPlayerLeftCommand);
        RegisterGameplayCommand(Keys.Right, turnPlayerRightCommand);
        RegisterGameplayCommand(Keys.Up, turnPlayerUpCommand);
        RegisterGameplayCommand(Keys.Down, turnPlayerDownCommand);

        RegisterGameplayCommand(Keys.A, usePrimaryWeaponCommand);
        RegisterGameplayCommand(Keys.B, useSecondaryWeaponCommand);

        RegisterGameplayCommand(Keys.E, openInventoryCommand);

        RegisterInventoryCommand(Keys.Escape, openGameCommand);
    }

    public void RegisterGameplayCommand(Keys key, ICommand command)
    {
        gameplayControllerMappings.Add(key, command);
    }

    public void RegisterInventoryCommand(Keys key, ICommand command)
    {
        inventoryControllerMappings.Add(key, command);
    }


}
