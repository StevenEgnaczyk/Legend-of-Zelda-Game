using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GoriyaBoomerangSprite : IEnemySprite
{
    private Texture2D GoriyaBoomerangTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;



    public GoriyaBoomerangSprite(Texture2D spritesheet)
    {
        GoriyaBoomerangTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 32, 32);

        frame0Rectangle = new Rectangle(291, 15, 5, 8);
        frame1Rectangle = new Rectangle(299, 15, 8, 8);
        frame2Rectangle = new Rectangle(308, 17, 8, 5);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        if (frame == 0)
        {
            sb.Draw(this.GoriyaBoomerangTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
        }
        else if (frame == 1)
        {
            sb.Draw(this.GoriyaBoomerangTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);
        }
        else
        {
            sb.Draw(this.GoriyaBoomerangTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);
        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Does not take damage.
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 32, 32);
        
        frame = time % 3;
    }
}