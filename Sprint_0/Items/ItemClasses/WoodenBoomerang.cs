using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WoodenBoomerang : IItem
{
    //item properties
    private int xPos;
    private int yPos;
    private int Width = 24;
    private int Height = 48;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;
    private ItemManager man;


    public WoodenBoomerang(ItemManager manager, int xPosition, int yPosition)
    {
        this.xPos = xPosition;
        this.yPos = yPosition;
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

    public int getX()
    {
        return this.xPos;
    }

    public int getY()
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