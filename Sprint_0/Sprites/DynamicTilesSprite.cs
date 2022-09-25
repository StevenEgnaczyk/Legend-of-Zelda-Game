using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
public class DynamicTileSprite
{
	private Dictionary<string, Texture2D> tiles;
	public DynamicTileSprite(ContentManager c)
	{
		tiles = new Dictionary<string, Texture2D>()
        {
            { "tile1", c.Load<Texture2D>("tiles/tile1")},
            { "tile2", c.Load<Texture2D>("tiles/tile2")},
			{ "tile3", c.Load<Texture2D>("tiles/tile3")},
			{ "tile4", c.Load<Texture2D>("tiles/tile4")},
			{ "tile5", c.Load<Texture2D>("tiles/tile5")},
			{ "tile6", c.Load<Texture2D>("tiles/tile6")},
			{ "tile7", c.Load<Texture2D>("tiles/tile7")},
			{ "tile8", c.Load<Texture2D>("tiles/tile8")},
			{ "tile9", c.Load<Texture2D>("tiles/tile9")},
			{ "tile10", c.Load<Texture2D>("tiles/tile10")}
		};
	}

    public void Draw(SpriteBatch spriteBatch, int x)
	{
		spriteBatch.Begin();
        Rectangle image = new Rectangle(0, 0, 64, 128);
		spriteBatch.Draw(tiles["tile" + x], new Vector2(350, 150), image, Color.White);
        Update();
        spriteBatch.End();
    }

	public void Update()
	{
	}
}