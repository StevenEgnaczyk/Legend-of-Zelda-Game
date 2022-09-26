using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class DynamicTilesCommand : ICommand
{
    private DynamicTileSprite _sprite;
    public DynamicTilesCommand(ContentManager c)
	{
        _sprite = new DynamicTileSprite(c);
	}

    public void drawSprite(SpriteBatch spriteBatch, int x)
	{
        _sprite.Draw(spriteBatch, x);
	}
}