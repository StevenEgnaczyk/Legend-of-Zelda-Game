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

	private QuitCommand _quitCommand;
	private TurnPlayerLeftCommand turnPlayerLeftCommand;
	private TurnPlayerRightCommand turnPlayerRightCommand;
	private TurnPlayerUpCommand turnPlayerUpCommand;
	private TurnPlayerDownCommand turnPlayerDownCommand;

	private UseWoodenSwordCommand useWoodenSwordCommand;
	private UseSwordBeamCommand useSwordBeamCommand;

	private CycleItemNextCommand cycleItemNextCommand;
	private CycleItemPrevCommand cycleItemPrevCommand;
	private DynamicTilesCommand _dynamicTilesCommand;
	private DynamicTilesCommandPrev _dynamicTilesCommandPrev;


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
				controllerMappings[key].Execute();
		}
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

}
