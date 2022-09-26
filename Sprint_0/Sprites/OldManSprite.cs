using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class OldManSprite : ISprite

{
	private Texture2D oldManTexture;
	private Rectangle sourceRectangle;
	private Rectangle destinationRectangle;
	private int oldManXPos;
	private int oldManYPos;

	public OldManSprite()
	{
		this.oldManTexture = Texture2DStorage.GetOldManSpriteSheet();
		oldManXPos = 200;
		oldManYPos = 200;
		destinationRectangle = new Rectangle(oldManXPos, oldManYPos, 16, 16);
		sourceRectangle = new Rectangle(1, 11, 16, 16);
	}

	public void Draw(SpriteBatch _spriteBatch)
	{
		_spriteBatch.Begin();
		_spriteBatch.Draw(this.oldManTexture, destinationRectangle, sourceRectangle, Color.White);
		Update();
		_spriteBatch.End();
	}

	public void Update()
	{
		destinationRectangle = new Rectangle(oldManXPos, oldManYPos, 16, 16);
	}
}
