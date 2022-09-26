using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class OldManState : IOldManState
{
    private OldMan oldMan1;
    public OldManState(OldMan oldMan1)
    {
        this.oldMan1 = oldMan1;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D oldManStill = Texture2DStorage.GetOldManSpriteSheet();
        Rectangle sourceRect = new Rectangle(1, 11, 16, 16);
        oldMan1.DrawSprite(spriteBatch, oldManStill, sourceRect);
    }
    public void Update()
    {
        oldMan1.x = 200;
        oldMan1.y = 200;
    }
}