using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Bomb : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;

    public Bomb()
    {
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D bombTexture = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getBombSprite();
        //spriteBatch.Draw(bombTexture, sourceRect);
    }

    public int getHeight()
    {
        return this.Height;
    }

    public int getWidth()
    {
        return this.Width;
    }

    public int getX()
    {
        return this.xPos;
    }

    public int getY()
    {
        return this.yPos;
    }

    public void Update()
    {
    }
}