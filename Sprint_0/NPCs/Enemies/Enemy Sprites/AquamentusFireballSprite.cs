using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class AquamentusFireballSprite : IEnemySprite
{
    private Texture2D AquamentusFireballTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    private Rectangle frame3Rectangle;
    public int damageBuffer { get; set; }


    public AquamentusFireballSprite(Texture2D spritesheet)
    {
        AquamentusFireballTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 64, 64);

        frame0Rectangle = new Rectangle(101, 14, 8, 10);
        frame1Rectangle = new Rectangle(110, 14, 8, 10);
        frame2Rectangle = new Rectangle(119, 14, 8, 10);
        frame3Rectangle = new Rectangle(128, 14, 8, 10);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        if (frame % 4 == 0)
        {
            sb.Draw(this.AquamentusFireballTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
        }
        else if (frame % 4 == 1)
        {
            sb.Draw(this.AquamentusFireballTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);
        }
        else if (frame % 4 == 2)
        {
            sb.Draw(this.AquamentusFireballTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);
        } else
        {
            sb.Draw(this.AquamentusFireballTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);
        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Aquamentus Fireball does not take damage
    }
    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 48, 48);
        
        frame = time % 4;
    }
}