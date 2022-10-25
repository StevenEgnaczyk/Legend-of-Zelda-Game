using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

    public ICommand useWoodenSwordCommand;
    public ICommand useSwordBeamCommand;
    public ICommand useBoomerangCommand;
    public ICommand useRedBowCommand;
    public ICommand useBlueBowCommand;
    public ICommand useFireCommand;
    public ICommand useBombCommand;

    public ICommand dieCommand;

    public ICommand cycleEnemyNextCommand;
    public ICommand cycleEnemyPreviousCommand;

    public ICommand cycleItemNextCommand;
    public ICommand cycleItemPrevCommand;
    public ICommand _dynamicTilesCommand;
    public ICommand _dynamicTilesCommandPrev;
    public ICommand resetCommand;

    public Keys[] state;

    public BuildCommands(Link linkPlayer)
    {
        controllerMappings = new Dictionary<Keys, ICommand>();

        _quitCommand = new QuitCommand();
        resetCommand = new ResetCommand(linkPlayer);
        turnPlayerLeftCommand = new TurnPlayerLeftCommand(linkPlayer);
        turnPlayerRightCommand = new TurnPlayerRightCommand(linkPlayer);
        turnPlayerUpCommand = new TurnPlayerUpCommand(linkPlayer);
        turnPlayerDownCommand = new TurnPlayerDownCommand(linkPlayer);

        useWoodenSwordCommand = new UseWoodenSwordCommand(linkPlayer);
        useSwordBeamCommand = new UseSwordBeamCommand(linkPlayer);
        useBoomerangCommand = new UseBoomerangCommand(linkPlayer);
        useRedBowCommand = new UseBowCommand(linkPlayer, "Red");
        useBlueBowCommand = new UseBowCommand(linkPlayer, "Blue");
        useFireCommand = new UseFireCommand(linkPlayer);
        useBombCommand = new UseBombCommand(linkPlayer);

        dieCommand = new DieCommand(linkPlayer);

        RegisterCommand(Keys.D0, _quitCommand);
        RegisterCommand(Keys.NumPad0, _quitCommand);
        RegisterCommand(Keys.Q, _quitCommand);
        RegisterCommand(Keys.R, resetCommand);

        RegisterCommand(Keys.Left, turnPlayerLeftCommand);
        RegisterCommand(Keys.Right, turnPlayerRightCommand);
        RegisterCommand(Keys.Up, turnPlayerUpCommand);
        RegisterCommand(Keys.Down, turnPlayerDownCommand);
        RegisterCommand(Keys.W, turnPlayerUpCommand);
        RegisterCommand(Keys.A, turnPlayerLeftCommand);
        RegisterCommand(Keys.S, turnPlayerDownCommand);
        RegisterCommand(Keys.D, turnPlayerRightCommand);

        RegisterCommand(Keys.P, cycleEnemyPreviousCommand);
        RegisterCommand(Keys.O, cycleEnemyNextCommand);

        RegisterCommand(Keys.Z, useWoodenSwordCommand);
        RegisterCommand(Keys.N, useSwordBeamCommand);
        RegisterCommand(Keys.D1, useBoomerangCommand);
        RegisterCommand(Keys.D2, useRedBowCommand);
        RegisterCommand(Keys.D3, useBlueBowCommand);
        RegisterCommand(Keys.D4, useFireCommand);
        RegisterCommand(Keys.D5, useBombCommand);

        RegisterCommand(Keys.E, dieCommand);
    }

    public void RegisterCommand(Keys key, ICommand command)
    {
        controllerMappings.Add(key, command);
    }

    
}
