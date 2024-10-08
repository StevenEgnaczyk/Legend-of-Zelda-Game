using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WoodenBoomerang : IItem
{
    //item properties
    private int xPos;
    private int yPos;
    private int Width = 20;
    private int Height = 32;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;
    private ItemManager man;


    public WoodenBoomerang(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = ((GlobalVariables.BLOCK_SIZE - this.Width) / 2) + xPosition;
        this.yPos = ((GlobalVariables.BLOCK_SIZE - this.Height) / 2) + yPosition;
        currentIndex = 0;
        bufferIndex = 0;
        man = manager;
        man.addItem(this);
    }

    public void delete()
    {
        man.removeItem(this);
    }

    //draw method for the item
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D woodenBoomerang = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getWoodenBoomerangSprites(currentIndex);
        Rectangle destRect = new Rectangle(this.xPos, this.yPos, this.Width, this.Height);
        spriteBatch.Draw(woodenBoomerang, destRect, sourceRect, Color.White);

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

    //update for animation
    public void Update()
    {
        if (currentIndex == 0)
        {
            bufferIndex++;
        }
        else
        {
            bufferIndex += 2;
        }

        if (bufferIndex == bufferMax)
        {
            bufferIndex = 0;
            currentIndex++;
            if (currentIndex == 4)
            {
                currentIndex = 0;
            }
        }
    }
}