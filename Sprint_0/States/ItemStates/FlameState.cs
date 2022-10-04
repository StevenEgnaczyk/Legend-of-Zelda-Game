using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;

public class FlameState : IItemState
{
    private Item item;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(52,11,16,16), new Rectangle(68, 11, 16, 16)
    };
    private int currentIndex;
    private int bufferIndex;
    private int bufferMax = 10;
    public FlameState(Item item)
    {
        this.item = item;
        currentIndex = 0;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        while (true)
        {
            Texture2D flameTexture = Texture2DStorage.GetOldManSpriteSheet();
            Rectangle sourceRect = itemSprites[currentIndex];
            item.DrawSprite(spriteBatch, flameTexture, sourceRect);
            




        }
    }
    public void Update()
    {
        //switch flame sprite
       

       
    }
    public void Next()
    {
        item.state = new ArrowState(item);
    }
    public void Prev()
    {
        item.state = new RupeeState(item);
    }
}