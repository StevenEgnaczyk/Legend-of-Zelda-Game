using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class BombState : IBombState
{
    private Bomb bomb;
    public BombState(Bomb bomb)
    {
        this.bomb = bomb;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D bombTexture = Texture2DStorage.GetLinkSpriteSheet();
        Rectangle sourceRect = new Rectangle(129, 185, 8, 16);
        bomb.DrawSprite(spriteBatch, bombTexture, sourceRect);
    }
    public void Update()
    {
        bomb.x = 400;
        bomb.y = 200;
    }
}