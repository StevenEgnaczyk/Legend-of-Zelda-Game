using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

public class NonMovingNonAnimatedSprite : ISprite
{
	private Texture2D mario;
	public NonMovingNonAnimatedSprite(ContentManager c)
	{
		mario = c.Load<Texture2D>("IDLEMARIO2");
    }

	public void Draw(SpriteBatch spriteBatch)
	{
        spriteBatch.Begin();

        Rectangle idleMario = new Rectangle(0, 0, 64, 128);
		spriteBatch.Draw(mario, new Vector2(350, 150), idleMario, Color.White);
        Update();
        spriteBatch.End();
    }

	public void Update()
	{
	}
}
