using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class Tile6State : ITileState
{
    private Tile tile;
    private static List<Rectangle> itemSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };
    private int currentIndex;

    public Tile6State(Tile tile)
    {
        this.tile = tile;
        currentIndex = 0;
    }

    public void Next()
    {
        tile.state = new Tile7State(tile);
    }
    public void Prev()
    {
        tile.state = new Tile5State(tile);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tile1 = Texture2DStorage.GetTile6Sprite();
        Rectangle sourceRect = itemSprites[currentIndex];
        tile.DrawSprite(spriteBatch, tile1, sourceRect);

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}