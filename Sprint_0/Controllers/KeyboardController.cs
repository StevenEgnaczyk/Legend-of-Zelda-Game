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
    private Keys[] state;
    public KeyboardController(Game1 game, ContentManager c, Link linkPlayer)
	{
		buildCommands = new BuildCommands(linkPlayer, game);
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
                    if (buildCommands.inventoryControllerMappings.ContainsKey(key))
                    {
                        if(!state.Contains(key))
                            {
                                buildCommands.inventoryControllerMappings[key].Execute();
                            }
                    }
                }
                state = pressedKeys;
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

            //Win Screen
            case "Sprint_0.GameStates.WinScreenState":
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
