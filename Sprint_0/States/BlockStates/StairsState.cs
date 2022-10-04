using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class StairsState : ITileState
{
    private Tile tile;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };
    private int currentIndex;

    public StairsState(Tile tile)
    {
        this.tile = tile;
        currentIndex = 0;
    }

    public void Next()
    {
        tile.state = new Statue1State(tile);
    }
    public void Prev()
    {
        tile.state = new BlueGapState(tile);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tile1 = Texture2DStorage.GetTile8Sprite();
        Rectangle sourceRect = itemSprites[currentIndex];
        tile.DrawSprite(spriteBatch, tile1, sourceRect);

    }
    public void Update()
    {
    }
}