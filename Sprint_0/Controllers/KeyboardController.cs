using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

public class KeyboardController : IController
{

	private Dictionary<Keys, ICommand> controllerMappings;

	private QuitCommand _quitCommand;

    public KeyboardController(ContentManager c)
	{

		controllerMappings = new Dictionary<Keys, ICommand>();

		//Initialize the different commands
		_quitCommand = new QuitCommand();

    }

	public void HandleEvents()
	{
		throw new NotImplementedException();
	}

	public int ProcessInput(Keys[] pressedKeys, SpriteBatch spriteBatch, int lastDrawn)
	{
		return -1;
	}

	public void ProcessInput()
	{
		throw new NotImplementedException();
	}

	public void Update()
	{
		throw new NotImplementedException();
	}
}
