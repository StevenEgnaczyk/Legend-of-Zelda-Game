using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

public class ChangeToNonAnimatedMovingCommand : ICommand
{
    private MovingNonAnimatedSprite _sprite;

    public ChangeToNonAnimatedMovingCommand(ContentManager c)
    {
        _sprite = new MovingNonAnimatedSprite(c);
    }

    public void drawSprite(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);

    }
}
