using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WoodenBoomerang : IItem
{

    private int xPos;
    private int yPos;
    private int Width = 16;
    private int Height = 16;

    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 20;

    public WoodenBoomerang()
    {
        currentIndex = 0;
        bufferIndex = 0;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D items = Texture2DStorage.GetItemSpritesheet();
        Rectangle sourceRect = ItemRectStorage.getWoodenBoomerangSprites(currentIndex);
        //item.DrawSprite(spriteBatch, items, sourceRect);

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