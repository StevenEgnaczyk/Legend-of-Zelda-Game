using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class TextSprite : ISprite

{
    private SpriteFont text;
    public TextSprite(ContentManager c)
	{
        text = c.Load<SpriteFont>("font");
    }

    public SpriteFont Text { get => text; set => text = value; }

    public void Draw(SpriteBatch _spriteBatch)
    {

    }

    public void Update()
	{
		
	}
}
