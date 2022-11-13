using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class FlameSprite : IEnemySprite
{
    private Texture2D OldManTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    //cant die add large number of hp so they cant die

    public FlameSprite(Texture2D spritesheet)
    {
        this.OldManTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        this.frame0Rectangle = new Rectangle(52, 11, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        OldManTexture = Texture2DStorage.GetOldManSpriteSheet();
        sb.Draw(OldManTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
    }

    public void drawDeath(int deadFrame, SpriteBatch sb)
    {
        throw new NotImplementedException();
    }
    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 64, 64);
    }

    public void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos)
    {
        throw new NotImplementedException();
    }
}