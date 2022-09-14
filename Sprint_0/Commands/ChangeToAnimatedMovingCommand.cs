using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Mime;

public class ChangeToAnimatedMovingCommand : ICommand
{
	private MovingAnimatedSprite _sprite;
	public ChangeToAnimatedMovingCommand(ContentManager c)
	{
        _sprite = new MovingAnimatedSprite(c, 1, 3);
    }

    public void drawSprite(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch, new Vector2(350, 150));
    }
}
