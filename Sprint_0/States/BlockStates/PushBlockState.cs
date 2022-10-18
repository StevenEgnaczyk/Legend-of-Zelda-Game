using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class PushBlockState : ITileState
{
    private Tile tile;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };
    private int currentIndex;

    public PushBlockState(Tile tile)
    {
        this.tile = tile;
        currentIndex = 0;
    }

    public void Next()
    {
        tile.state = new WhiteBrickState(tile);
    }
    public void Prev()
    {
        tile.state = new Statue2State(tile);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tile = Texture2DStorage.GetDungeonTileset();
        Rectangle sourceRect = itemSprites[currentIndex];
        Rectangle destRect = Texture2DStorage.getBlockRect(9);
        spriteBatch.Draw(tile, sourceRect, destRect, Color.White);

    }
    public void Update()
    {
    }
}