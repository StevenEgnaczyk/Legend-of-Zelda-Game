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
    public ICommand transitionToInventoryCommand;
    public ICommand openGameCommand;
    public ICommand transitionToGameCommand;

    public ICommand cycleEnemyNextCommand;
    public ICommand cycleEnemyPreviousCommand;

    public ICommand cycleItemNextCommand;
    public ICommand cycleItemPrevCommand;
    public ICommand _dynamicTilesCommand;
    public ICommand _dynamicTilesCommandPrev;
    public ICommand resetCommand;

    public ICommand cycleInventoryRightCommand;
    public ICommand cycleInventoryLeftCommand;

    public ICommand muteCommand;
    public ICommand volUpCommand;
    public ICommand volDownCommand;

    public Keys[] state;

    public BuildCommands(Link linkPlayer, Game1 game)
    {
        gameplayControllerMappings = new Dictionary<Keys, ICommand>();
        inventoryControllerMappings = new Dictionary<Keys, ICommand>();

        _quitCommand = new QuitCommand();
        turnPlayerLeftCommand = new TurnPlayerLeftCommand(linkPlayer);
        turnPlayerRightCommand = new TurnPlayerRightCommand(linkPlayer);
        turnPlayerUpCommand = new TurnPlayerUpCommand(linkPlayer);
        turnPlayerDownCommand = new TurnPlayerDownCommand(linkPlayer);

        usePrimaryWeaponCommand = new UsePrimaryWeaponCommand(linkPlayer);
        useSecondaryWeaponCommand = new UseSecondaryWeaponCommand(linkPlayer);

        openInventoryCommand = new ChangeToInventoryStateCommand(game);
        transitionToInventoryCommand = new TransitionToInventoryCommand(game);
        openGameCommand = new ChangeToGameplayStateCommand(game);
        transitionToGameCommand = new TransitionToGameCommmand(game);

        cycleInventoryRightCommand = new CycleInventoryRight(linkPlayer.inventory);
        cycleInventoryLeftCommand = new CycleInventoryLeft(linkPlayer.inventory);

        muteCommand = new MuteCommand();
        volUpCommand = new VolUpCommand();
        volDownCommand = new VolDownCommand();


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

        RegisterGameplayCommand(Keys.E, transitionToInventoryCommand);

        RegisterGameplayCommand(Keys.M, muteCommand);
        RegisterGameplayCommand(Keys.L, volUpCommand);
        RegisterGameplayCommand(Keys.K, volDownCommand);
        

        RegisterInventoryCommand(Keys.Escape, transitionToGameCommand);
        RegisterInventoryCommand(Keys.Right, cycleInventoryRightCommand);
        RegisterInventoryCommand(Keys.Left, cycleInventoryLeftCommand);

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
