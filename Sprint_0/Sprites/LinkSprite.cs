using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkSprite : ISprite

{
    private Sprint_0.Game1 game1;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D linkSprite;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int linkXPos;
    private int linkYPos;

    private int linkXRectStart;
    private int linkYRectStart;

    public LinkSprite()
    {
        game1 = new Sprint_0.Game1();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D spriteSheet = Texture2DStorage.GetLinkSpriteSheet();

        _graphics = game1._graphics;
        //_spriteBatch = game1._spriteBatch;

        linkXPos = 100;
        linkYPos = 100;
        destinationRectangle = new Rectangle(linkXPos, linkYPos, 16, 16);

        linkXRectStart = 1;
        linkYRectStart = 11;
        sourceRectangle = new Rectangle(linkXRectStart, linkYRectStart, 16, 16);

    }

    public void Draw()
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
        Update();
        _spriteBatch.End();
        
    }

    public void Update()
    {
        destinationRectangle = new Rectangle(linkXPos, linkYPos, 16, 16);
    }
}
