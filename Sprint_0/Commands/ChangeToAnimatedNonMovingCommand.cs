using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

public class ChangeToAnimatedNonMovingCommand : ICommand
{

    private NonMovingAnimatedSprite _sprite;
    public ChangeToAnimatedNonMovingCommand(ContentManager c)
    {
        _sprite = new NonMovingAnimatedSprite(c, 1, 3);
    }

    public void drawSprite(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch, new Vector2(350, 150));
    }

}
