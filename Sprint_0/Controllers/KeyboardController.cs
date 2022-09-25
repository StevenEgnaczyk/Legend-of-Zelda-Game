using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

public class KeyboardController : IController
{
	//5 different commands
	private ChangeToAnimatedMovingCommand _changeToAnimatedMovingCommand;
    private ChangeToAnimatedNonMovingCommand _changeToAnimatedNonMovingCommand;
    private ChangeToNonAnimatedMovingCommand _changeToNonAnimatedMovingCommand;
    private ChangeToNonAnimatedNonMovingCommand _changeToNonAnimatedNonMovingCommand;
    private QuitCommand _quitCommand;
	private DynamicTilesCommand _dynamicTilesCommand;
	private int x = 1;


    public KeyboardController(ContentManager c)
	{

		//Initialize the 5 different commands
		_changeToAnimatedMovingCommand = new ChangeToAnimatedMovingCommand(c);
		_changeToAnimatedNonMovingCommand = new ChangeToAnimatedNonMovingCommand(c);
		_changeToNonAnimatedMovingCommand = new ChangeToNonAnimatedMovingCommand(c);
		_changeToNonAnimatedNonMovingCommand = new ChangeToNonAnimatedNonMovingCommand(c);
		_dynamicTilesCommand = new DynamicTilesCommand(c);
		_quitCommand = new QuitCommand();


    }

	public void HandleEvents()
	{
		throw new NotImplementedException();
	}

	public int ProcessInput(Keys[] pressedKeys, SpriteBatch spriteBatch, int lastDrawn)
	{
		if (pressedKeys.Length == 0)
		{
			if (lastDrawn == 1)
			{
                _changeToNonAnimatedNonMovingCommand.drawSprite(spriteBatch);
            } else if (lastDrawn == 2)
			{
                _changeToAnimatedNonMovingCommand.drawSprite(spriteBatch);
            }
            else if (lastDrawn == 3)
            {
                _changeToNonAnimatedMovingCommand.drawSprite(spriteBatch);
            }
            else if (lastDrawn == 4)
            {
                _changeToAnimatedMovingCommand.drawSprite(spriteBatch);
            }
			else if (lastDrawn == 5)
            {
                _dynamicTilesCommand.drawSprite(spriteBatch, x);
            }
        }
        foreach (Keys k in pressedKeys)
		{
			if (k.Equals(Keys.NumPad0) || k.Equals(Keys.D0))
			{
				_quitCommand.QuitProgram();
			}
			else if (k.Equals(Keys.NumPad1) || k.Equals(Keys.D1))
			{
				_changeToNonAnimatedNonMovingCommand.drawSprite(spriteBatch);
				lastDrawn = 1;
			}
			else if (k.Equals(Keys.NumPad2) || k.Equals(Keys.D2))
			{
				_changeToAnimatedNonMovingCommand.drawSprite(spriteBatch);
				lastDrawn = 2;
			}
			else if (k.Equals(Keys.NumPad3) || k.Equals(Keys.D3))
			{
				_changeToNonAnimatedMovingCommand.drawSprite(spriteBatch);
				lastDrawn = 3;
			}
			else if (k.Equals(Keys.NumPad4) || k.Equals(Keys.D4))
			{
				_changeToAnimatedMovingCommand.drawSprite(spriteBatch);
				lastDrawn = 4;
			}
			else if (k.Equals(Keys.T))
			{
				_dynamicTilesCommand.drawSprite(spriteBatch, x);
				lastDrawn = 5;
				++x;
			}
        }
		if(x > 10){
			x=1;
		}
		return lastDrawn;
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
