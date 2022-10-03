using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;

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
	private ICommand useBowCommand;
    private ICommand useFireCommand;

    private ICommand cycleItemNextCommand;
	private ICommand cycleItemPrevCommand;
	private ICommand _dynamicTilesCommand;
	private ICommand _dynamicTilesCommandPrev;


    public KeyboardController(ContentManager c, Link linkPlayer, Item itemPlayer, Tile tilePlayer)
	{

		controllerMappings = new Dictionary<Keys, ICommand>();

		//Initialize the different commands
		_quitCommand = new QuitCommand();
		turnPlayerLeftCommand = new TurnPlayerLeftCommand(linkPlayer);
		turnPlayerRightCommand = new TurnPlayerRightCommand(linkPlayer);
		turnPlayerUpCommand = new TurnPlayerUpCommand(linkPlayer);
		turnPlayerDownCommand = new TurnPlayerDownCommand(linkPlayer);

		useWoodenSwordCommand = new UseWoodenSwordCommand(linkPlayer);
		useSwordBeamCommand = new UseSwordBeamCommand(linkPlayer);
		useBoomerangCommand = new UseBoomerangCommand(linkPlayer);
		useBowCommand = new UseBowCommand(linkPlayer);
		useFireCommand = new UseFireCommand(linkPlayer);

		cycleItemNextCommand = new CycleItemNextCommand(itemPlayer);
		cycleItemPrevCommand = new CycleItemPrevCommand(itemPlayer);

		_dynamicTilesCommand = new DynamicTilesCommand(tilePlayer);
		_dynamicTilesCommandPrev = new DynamicTilesCommandPrev(tilePlayer);

		RegisterCommand(Keys.D0, _quitCommand);
		RegisterCommand(Keys.NumPad0, _quitCommand);

		RegisterCommand(Keys.Left, turnPlayerLeftCommand);
		RegisterCommand(Keys.Right, turnPlayerRightCommand);
		RegisterCommand(Keys.Up, turnPlayerUpCommand);
		RegisterCommand(Keys.Down, turnPlayerDownCommand);

		RegisterCommand(Keys.Z, useWoodenSwordCommand);
		RegisterCommand(Keys.N, useSwordBeamCommand);
        RegisterCommand(Keys.D1, useBoomerangCommand);
        RegisterCommand(Keys.D2, useBowCommand);
        RegisterCommand(Keys.D3, useFireCommand);

        RegisterCommand(Keys.U, cycleItemNextCommand);
		RegisterCommand(Keys.I, cycleItemPrevCommand);
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
			if (controllerMappings.ContainsKey(key))
			{
				controllerMappings[key].Execute();
			}
		}
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

}
