using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class MouseController : IController
{

    private ChangeToAnimatedMovingCommand _changeToAnimatedMovingCommand;
    private ChangeToAnimatedNonMovingCommand _changeToAnimatedNonMovingCommand;
    private ChangeToNonAnimatedMovingCommand _changeToNonAnimatedMovingCommand;
    private ChangeToNonAnimatedNonMovingCommand _changeToNonAnimatedNonMovingCommand;
    private QuitCommand _quitCommand;

    public MouseController(ContentManager c)
	{

        _changeToAnimatedMovingCommand = new ChangeToAnimatedMovingCommand(c);
        _changeToAnimatedNonMovingCommand = new ChangeToAnimatedNonMovingCommand(c);
        _changeToNonAnimatedMovingCommand = new ChangeToNonAnimatedMovingCommand(c);
        _changeToNonAnimatedNonMovingCommand = new ChangeToNonAnimatedNonMovingCommand(c);
        _quitCommand = new QuitCommand();

    }

	public void HandleEvents()
	{
		throw new NotImplementedException();
	}

	public void ProcessInput()
	{
		throw new NotImplementedException();
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

    internal int ProcessInput(MouseState mouseState, SpriteBatch spriteBatch, int lastDrawn)
    {
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            if (mousePos.X > 0 && mousePos.X < 400 && mousePos.Y > 0 && mousePos.Y < 200)
            {
                Debug.WriteLine("Here");
                _changeToNonAnimatedNonMovingCommand.drawSprite(spriteBatch);
                lastDrawn = 1;
            } else if (mousePos.X >= 400 && mousePos.X < 800 && mousePos.Y > 0 && mousePos.Y < 200)
            {
                _changeToAnimatedNonMovingCommand.drawSprite(spriteBatch);
                lastDrawn = 2;
            } else if (mousePos.X > 0 && mousePos.X < 400 && mousePos.Y >= 200 && mousePos.Y <= 400) 
            {
                _changeToNonAnimatedMovingCommand.drawSprite(spriteBatch);
                lastDrawn = 3;
            } else
            {
                _changeToAnimatedMovingCommand.drawSprite(spriteBatch);
                lastDrawn = 4;
            }
        } else if (mouseState.RightButton == ButtonState.Pressed)
        {
            _quitCommand.QuitProgram();
        } else
        {
            if (lastDrawn == 1)
            {
                _changeToNonAnimatedNonMovingCommand.drawSprite(spriteBatch);
            }
            else if (lastDrawn == 2)
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
        }

        return lastDrawn;
    }
}
