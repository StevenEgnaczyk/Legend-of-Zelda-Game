using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class FlameSprite : IEnemySprite
{
    private Texture2D FlameTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    public int damageBuffer { get; set; }

    public FlameSprite(Texture2D spritesheet)
    {
        FlameTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 32, 32);

        frame0Rectangle = new Rectangle(52, 11, 16, 16);
        frame1Rectangle = new Rectangle(68, 11, 16, 16);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        if (frame == 0)
        {
            sb.Draw(this.FlameTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.FlameTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Does not take damage
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

        if (time % 2 == 0)
        {
            frame = 0;

        }
        else
        {
            frame = 1;
        }
    }
}