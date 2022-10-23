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
	public BuildCommands buildCommands;

	public Dictionary<Keys, ICommand> controllerMappings;

    public Keys[] state;

    public KeyboardController(ContentManager c, Link linkPlayer)
	{
		buildCommands = new BuildCommands(linkPlayer);
		controllerMappings = buildCommands.controllerMappings;
		state = buildCommands.state;
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
