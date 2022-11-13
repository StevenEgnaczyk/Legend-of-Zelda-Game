using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class BladeTrapSprite : IEnemySprite
{
    private Texture2D BladeTrapTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    //cant die add large number of hp so they cant die

    public BladeTrapSprite(Texture2D spritesheet)
    {
        this.BladeTrapTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        this.frame0Rectangle = new Rectangle(164, 59, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        BladeTrapTexture = Texture2DStorage.getEnemySpritesheet();
        sb.Draw(BladeTrapTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
    }

    public void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos)
    {
        throw new NotImplementedException();
    }
    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 64, 64);
    }
}