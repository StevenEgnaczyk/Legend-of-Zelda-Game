using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class FlameSprite : ISprite

{
	private Texture2D FlameTexture;
	private Rectangle sourceRectangle;
	private Rectangle sourceRectangle2;
	private Rectangle destinationRectangle;
	private int flameXPos;
	private int flameYPos;

	public FlameSprite()
	{
		this.FlameTexture = Texture2DStorage.GetOldManSpriteSheet();
		flameXPos = 200;
		flameYPos = 200;
		destinationRectangle = new Rectangle(flameXPos, flameYPos, 16, 16);
        Rectangle[] sourceRectangle;
		sourceRectangle = new Rectangle[2];
        sourceRectangle[0] = new Rectangle(52, 11, 16, 16);
        sourceRectangle[1] = new Rectangle(69, 11, 16, 16);
    }

	public void Draw(SpriteBatch _spriteBatch)
	{
		_spriteBatch.Begin();
		_spriteBatch.Draw(this.FlameTexture, destinationRectangle, sourceRectangle, Color.DarkGray);
		Update();
		_spriteBatch.End();
	}

	public void Update()
	{
		destinationRectangle = new Rectangle(flameXPos, flameYPos, 16, 16);
	}
}
