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

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.DrawString(text, "Credits\nProgram Made By: Steven Egnaczyk\nSprites From: https://www.mariouniverse.com/sprites-nes-smb/", new Vector2(200, 400), Color.Black);
        spriteBatch.End();
    }

    public void Update()
	{
		
	}
}
