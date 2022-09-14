using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class ChangeToNonAnimatedNonMovingCommand : ICommand
{
    private NonMovingNonAnimatedSprite _sprite;
    public ChangeToNonAnimatedNonMovingCommand(ContentManager c)
	{
        _sprite = new NonMovingNonAnimatedSprite(c);
	}

    public void drawSprite(SpriteBatch spriteBatch)
	{
        _sprite.Draw(spriteBatch);
	}
}
