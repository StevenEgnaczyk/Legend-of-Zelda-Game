using Microsoft.Xna.Framework.Content;
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
    int index;
    public KeyboardController(Game1 game, ContentManager c, Link linkPlayer)
	{
		buildCommands = new BuildCommands(linkPlayer, game);
        index = 0;
    }

	public void ProcessInput(IState gameplayState)
	{
        //Get the pressed keys
		Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

		switch (gameplayState.ToString())
		{
			//Gameplay State
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

			//Inventory State
			case "Sprint_0.GameStates.InventoryState":
                foreach (Keys key in pressedKeys)
                {
                    if (key.Equals(Keys.Left) || key.Equals(Keys.Right))
                    {
                        index += 1;
                        if (index > 4)
                        {
                            buildCommands.inventoryControllerMappings[key].Execute();
                            index = 0;
                        }
                    } else if (buildCommands.inventoryControllerMappings.ContainsKey(key))
                    {
                        if (buildCommands.state.Contains(key)) //checks for the commands in state
                        {
                            buildCommands.inventoryControllerMappings[key].Execute();
                        }
                    }

                }
                buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
                break;

			//Startup Screen
            case "Sprint_0.GameStates.StartupScreenState":
                foreach (Keys key in pressedKeys)
                {
                    //checks for registered commands
                    if (buildCommands.startupControllerMappings.ContainsKey(key))
                    {
                        if (buildCommands.state.Contains(key)) //checks for the commands in state
                        {
                            buildCommands.startupControllerMappings[key].Execute();
                        }
                    }
                }
                buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
                break;
            
            //Death Screen
            case "Sprint_0.GameStates.DeathScreenState":
                foreach (Keys key in pressedKeys)
                {
                    //checks for registered commands
                    if (buildCommands.startupControllerMappings.ContainsKey(key))
                    {
                        if (buildCommands.state.Contains(key)) //checks for the commands in state
                        {
                            buildCommands.startupControllerMappings[key].Execute();
                        }
                    }
                }
                buildCommands.state = pressedKeys; //sets state to compare to new pressed keys
                break;
        }
	}
}
