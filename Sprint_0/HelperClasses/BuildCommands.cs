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
    public Dictionary<Keys, ICommand> controllerMappings;

    public ICommand _quitCommand;
    public ICommand turnPlayerLeftCommand;
    public ICommand turnPlayerRightCommand;
    public ICommand turnPlayerUpCommand;
    public ICommand turnPlayerDownCommand;

    public ICommand usePrimaryWeaponCommand;
    public ICommand useSecondaryWeaponCommand;

    public ICommand openInventoryCommand;

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
        controllerMappings = new Dictionary<Keys, ICommand>();

        _quitCommand = new QuitCommand();
        resetCommand = new ResetCommand(linkPlayer);
        turnPlayerLeftCommand = new TurnPlayerLeftCommand(linkPlayer);
        turnPlayerRightCommand = new TurnPlayerRightCommand(linkPlayer);
        turnPlayerUpCommand = new TurnPlayerUpCommand(linkPlayer);
        turnPlayerDownCommand = new TurnPlayerDownCommand(linkPlayer);

        usePrimaryWeaponCommand = new UsePrimaryWeaponCommand(linkPlayer);
        useSecondaryWeaponCommand = new UseSecondaryWeaponCommand(linkPlayer);

        openInventoryCommand = new openInventoryCommand(game);

        dieCommand = new DieCommand(linkPlayer);

        RegisterCommand(Keys.D0, _quitCommand);
        RegisterCommand(Keys.NumPad0, _quitCommand);
        RegisterCommand(Keys.Q, _quitCommand);
        RegisterCommand(Keys.R, resetCommand);

        RegisterCommand(Keys.Left, turnPlayerLeftCommand);
        RegisterCommand(Keys.Right, turnPlayerRightCommand);
        RegisterCommand(Keys.Up, turnPlayerUpCommand);
        RegisterCommand(Keys.Down, turnPlayerDownCommand);

        RegisterCommand(Keys.A, usePrimaryWeaponCommand);
        RegisterCommand(Keys.B, useSecondaryWeaponCommand);

        RegisterCommand(Keys.E, openInventoryCommand);
    }

    public void RegisterCommand(Keys key, ICommand command)
    {
        controllerMappings.Add(key, command);
    }

    
}
