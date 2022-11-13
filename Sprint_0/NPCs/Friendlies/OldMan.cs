using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
public class OldMan
{

    //public OldManSprite sprite;
    public float x, y;
    public SpriteBatch _spriteBatch;
    
    public OldMan()
    {
        x = 200;
        y = 200;
    }
    public void Update()
    {
        throw new NotImplementedException();
    }
    public void Draw(SpriteBatch _spriteBatch)
    {

    }
    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D oldManSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)x, (int)y, sourceRect.Width * 3, sourceRect.Height * 3);
        _spriteBatch.Draw(oldManSprite, destinationRect, sourceRect, Color.White);
    }
}
