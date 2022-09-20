using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class MouseController : IController
{

    private QuitCommand _quitCommand;

    public MouseController(ContentManager c)
	{

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

    internal int ProcessInput(SpriteBatch spriteBatch, int lastDrawn)
    {
		MouseState mouseState = Mouse.GetState();

		if (mouseState.LeftButton == ButtonState.Pressed)
		{
			return -1;
		} else if (mouseState.RightButton == ButtonState.Pressed)
		{
			_quitCommand.Execute();
		}
    }
}
