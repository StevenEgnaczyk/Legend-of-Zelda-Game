﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using Sprint_0.GameStates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

	public void ProcessInput(IState gameplayState)
	{
		Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

		switch (gameplayState.ToString())
		{
			case "Sprint_0.GameStates.GameplayState":

				foreach (Keys key in pressedKeys)
				{
					//checks for registered commands
					if (buildCommands.gameplayControllerMappings.ContainsKey(key))
					{
						if (buildCommands.state.Contains(key)) //checks for the commands in state
						{
							buildCommands.gameplayControllerMappings[key].Execute();
						}
					}
				}
				buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
				break;
			case "Sprint_0.GameStates.InventoryState":
                foreach (Keys key in pressedKeys)
                {
                    //checks for registered commands
                    if (buildCommands.inventoryControllerMappings.ContainsKey(key))
                    {
                        if (buildCommands.state.Contains(key)) //checks for the commands in state
                        {
                            buildCommands.inventoryControllerMappings[key].Execute();
                        }
                    }
                }
                buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
                break;
        }
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

}
