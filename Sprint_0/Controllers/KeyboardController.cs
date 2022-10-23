using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KeyboardController : IController
{

	private Dictionary<Keys, ICommand> controllerMappings;

	private ICommand _quitCommand;
	private ICommand turnPlayerLeftCommand;
	private ICommand turnPlayerRightCommand;
	private ICommand turnPlayerUpCommand;
	private ICommand turnPlayerDownCommand;

	private ICommand useWoodenSwordCommand;
	private ICommand useSwordBeamCommand;
    private ICommand useBoomerangCommand;
	private ICommand useRedBowCommand;
    private ICommand useBlueBowCommand;
    private ICommand useFireCommand;
	private ICommand useBombCommand;

    private ICommand dieCommand;

	private ICommand cycleEnemyNextCommand;
    private ICommand cycleEnemyPreviousCommand;

    private ICommand cycleItemNextCommand;
	private ICommand cycleItemPrevCommand;
	private ICommand _dynamicTilesCommand;
	private ICommand _dynamicTilesCommandPrev;
	private ICommand resetCommand;

	private Keys[] state;



    public KeyboardController(ContentManager c, Link linkPlayer)
	{

		controllerMappings = new Dictionary<Keys, ICommand>();

		//Initialize the different commands
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
        RegisterCommand(Keys.I, cycleItemNextCommand);
		RegisterCommand(Keys.U, cycleItemPrevCommand);
		RegisterCommand(Keys.T, _dynamicTilesCommand);
		RegisterCommand(Keys.Y, _dynamicTilesCommandPrev);


    }

	public void RegisterCommand(Keys key, ICommand command)
	{
		controllerMappings.Add(key, command);
	}

	public void HandleEvents()
	{
		throw new NotImplementedException();
	}

	public void ProcessInput()
	{
		Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

		foreach(Keys key in pressedKeys)
		{
			//checks for registered commands
			if (controllerMappings.ContainsKey(key))
			{
				if(state.Contains(key)) //checks for the commands in state
				{
					controllerMappings[key].Execute();
				}
			}
		}
		state = pressedKeys; //sets state to compare to new pressed keys
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

}
