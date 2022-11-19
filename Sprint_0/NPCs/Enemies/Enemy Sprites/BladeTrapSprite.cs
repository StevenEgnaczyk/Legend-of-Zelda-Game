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

    public BladeTrapSprite(Texture2D spritesheet)
    {
        this.BladeTrapTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        this.frame0Rectangle = new Rectangle(164, 59, 16, 16);

    }

    public void draw(SpriteBatch sb)
    {
        BladeTrapTexture = Texture2DStorage.getEnemySpritesheet();
        sb.Draw(BladeTrapTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Blade Trap doesnt take damage
    }

    public void update(int xPos, int yPos, int facingDirection, int time)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 64, 64);
    }
}