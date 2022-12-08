using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Bomb : IItem
{

    private float xPos;
    private float yPos;
    private int Width = 24;
    private int Height = 42;
    private ItemManager man;


    public Bomb(ItemManager manager, int xPosition, int yPosition)
    {

        this.xPos = ((GlobalVariables.BLOCK_SIZE - this.Width) / 2) + xPosition;
        this.yPos = ((GlobalVariables.BLOCK_SIZE - this.Height) / 2) + yPosition;
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        man.removeItem(this);
    }

    //draw method for item
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D bomb = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getBombSprite();
        Rectangle destRect = new Rectangle((int)this.xPos, (int)this.yPos, this.Width, this.Height);
        spriteBatch.Draw(bomb, destRect, sourceRect, Color.White);
    }

    //get classes for the item
    public int getHeight()
    {
        return this.Height;
    }

    public int getWidth()
    {
        return this.Width;
    }

    public float getX()
    {
        return this.xPos;
    }

    public float getY()
    {
        return this.yPos;
    }

    public void Update()
    {
    }
}