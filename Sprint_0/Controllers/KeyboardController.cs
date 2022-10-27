using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KeyboardController : IController
{
	public BuildCommands buildCommands;

    public KeyboardController(Game1 game, ContentManager c, Link linkPlayer)
	{
		buildCommands = new BuildCommands(linkPlayer, game);
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
			if (buildCommands.controllerMappings.ContainsKey(key))
			{
				if(buildCommands.state.Contains(key)) //checks for the commands in state
				{
					buildCommands.controllerMappings[key].Execute();
				}
			}
		}
		buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

}
