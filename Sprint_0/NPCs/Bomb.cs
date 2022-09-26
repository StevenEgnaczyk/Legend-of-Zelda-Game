using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
public class Bomb
{
    public IBombState state;
    public BombSprite sprite;
    public float x, y;
    public SpriteBatch _spriteBatch;
    
    public Bomb()
    {
        state = new BombState(this);
        x = 400;
        y = 200;
    }
    public void Update()
    {
        throw new NotImplementedException();
    }
    public void Draw(SpriteBatch _spriteBatch)
    {
        state.Draw(_spriteBatch);
    }
    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D bombSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)x, (int)y, sourceRect.Width * 3, sourceRect.Height * 3);
        _spriteBatch.Draw(bombSprite, destinationRect, sourceRect, Color.White);
    }
}
