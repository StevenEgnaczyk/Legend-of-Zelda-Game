using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class AdamSandlerGolfBallSprite : IEnemySprite
{
    private Texture2D AdamSandlerGolfBallTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    private Rectangle frame3Rectangle;

    public int damageBuffer { get; set; }

    public AdamSandlerGolfBallSprite(Texture2D spritesheet)
    {
        AdamSandlerGolfBallTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 12, 12);

        frame0Rectangle = new Rectangle(193, 218, 4, 4);
        frame1Rectangle = new Rectangle(199, 218, 4, 4);
        frame2Rectangle = new Rectangle(205, 218, 4, 4);
        frame3Rectangle = new Rectangle(211, 218, 4, 4);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        if ((0 <= frame % 16) || (frame % 16 < 4))
        {
            sb.Draw(this.AdamSandlerGolfBallTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
        }
        else if ((4 <= frame % 16) || (frame % 16 < 8))
        {
            sb.Draw(this.AdamSandlerGolfBallTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);
        }
        else if ((8 <= frame % 16) || (frame % 16 < 12))
        {
            sb.Draw(this.AdamSandlerGolfBallTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);
        }
        else 
        {
            sb.Draw(this.AdamSandlerGolfBallTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);
        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Does not take damage.
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 12, 12);

        frame++;
    }
}