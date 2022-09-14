using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Windows;

public class MovingNonAnimatedSprite : ISprite
{
	private Texture2D mario;
	private int mario_x_pos;

	public MovingNonAnimatedSprite(ContentManager c)
	{
        mario = c.Load<Texture2D>("IDLEMARIO2");
		mario_x_pos = 250;
    }

	public void Draw(SpriteBatch spriteBatch)
	{
		mario_x_pos++;
		Debug.WriteLine(mario_x_pos);
        spriteBatch.Begin();
        Rectangle idleMario = new Rectangle(0, 0, 64, 128);
        spriteBatch.Draw(mario, new Vector2(mario_x_pos, 150), idleMario, Color.White);
        Update();
        spriteBatch.End();
    }

	public void Update()
	{
		mario_x_pos++;
		if (mario_x_pos > 800)
		{
			mario_x_pos = 0;
		}
	}
}
