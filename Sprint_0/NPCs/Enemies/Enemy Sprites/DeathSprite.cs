using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class DeathSprite : IEnemySprite
{
    private Texture2D DeathTexture;
    private int frame;

    private Rectangle destinationRectangle;

    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    private Rectangle frame3Rectangle;

    public DeathSprite(Texture2D spritesheet)
    {
        DeathTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 0, 0);

        frame0Rectangle = new Rectangle(0, 0, 15, 16);
        frame1Rectangle = new Rectangle(16, 0, 15, 16);
        frame2Rectangle = new Rectangle(35, 3, 9, 10);
        frame3Rectangle = new Rectangle(51, 3, 9, 10);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        if (frame == 0)
        {
            sb.Draw(DeathTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else if (frame == 1)
        {
            sb.Draw(DeathTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
        else if (frame == 2)
        {
            sb.Draw(DeathTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);

        }
        else if (frame == 3)
        {
            sb.Draw(DeathTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);

        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Does not take damage
    }
    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 48, 64);

        frame++;
    }
}