using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class BombSprite : ISprite

{
	private Texture2D bombTexture;
	private Rectangle sourceRectangle;
	private Rectangle destinationRectangle;
	private int bombXPos;
	private int bombYPos;

	public BombSprite()
	{
		this.bombTexture = Texture2DStorage.GetOldManSpriteSheet();
		bombXPos = 200;
		bombYPos = 200;
		destinationRectangle = new Rectangle(bombXPos, bombYPos, 16, 16);
		sourceRectangle = new Rectangle(129, 185, 8, 16);
	}

	public void Draw(SpriteBatch _spriteBatch)
	{
		_spriteBatch.Begin();
		_spriteBatch.Draw(this.bombTexture, destinationRectangle, sourceRectangle, Color.White);
		Update();
		_spriteBatch.End();
	}

	public void Update()
	{
		destinationRectangle = new Rectangle(bombXPos, bombYPos, 16, 16);
	}
}
