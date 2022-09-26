using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkSprite : ISprite

{

    private Texture2D linkTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int linkXPos;
    private int linkYPos;

    private int linkXRectStart;
    private int linkYRectStart;

    public LinkSprite()
    {
        this.linkTexture = Texture2DStorage.GetLinkSpriteSheet();

        linkXPos = 100;
        linkYPos = 100;
        destinationRectangle = new Rectangle(linkXPos, linkYPos, 16, 16);

        linkXRectStart = 1;
        linkYRectStart = 11;
        sourceRectangle = new Rectangle(linkXRectStart, linkYRectStart, 16, 16);

    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(this.linkTexture, destinationRectangle, sourceRectangle, Color.White);
        Update();
        _spriteBatch.End();
        
    }

    public void Update()
    {
        destinationRectangle = new Rectangle(linkXPos, linkYPos, 16, 16);
    }
}
