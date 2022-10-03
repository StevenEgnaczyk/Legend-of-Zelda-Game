using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class ItemSprite : ISprite

{

    private Texture2D itemTexture;

    private Rectangle destinationRectangle;
    private Rectangle sourceRectangle;

    private int itemXPos;
    private int itemYPos;

    private int itemXRectStart;
    private int itemYRectStart;

    public ItemSprite()
    {
        this.itemTexture = Texture2DStorage.GetItemSpritesheet();

        itemXPos = 500;
        itemYPos = 300;
        destinationRectangle = new Rectangle(itemXPos, itemYPos, 50, 50);
        // 1
        itemXRectStart = 0; 
        //11
        itemYRectStart = 0;
        sourceRectangle = new Rectangle(itemXRectStart, itemYRectStart, 16, 16);

    }
    // this.sourceRectangle,
    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Begin();
        _spriteBatch.Draw(this.itemTexture, this.destinationRectangle, Color.White);
        Update();
        _spriteBatch.End();
        
    }

    public void Update()
    {
        destinationRectangle = new Rectangle(itemXPos, itemYPos, 16, 16);
    }
}
