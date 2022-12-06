using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Security.Cryptography;

public class AquamentusSprite : IEnemySprite
{
    private Texture2D AquamentusTexture;
    private int frame;

    private Rectangle destinationRectangle;

    //Note: Projectiles shoots only on frame 0,1
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    private Rectangle frame3Rectangle;
    //2 hp but only can take damage from bombs add animation but allow for everything to do damage

    public int damageBuffer { get; set; }

    public AquamentusSprite(Texture2D spritesheet)
    {
        AquamentusTexture = spritesheet;

        destinationRectangle = new Rectangle(300, 400, 100, 128);

        frame0Rectangle = new Rectangle(1, 11, 24, 32);
        frame1Rectangle = new Rectangle(26, 11, 24, 32);
        frame2Rectangle = new Rectangle(51, 11, 24, 32);
        frame3Rectangle = new Rectangle(76, 11, 24, 32);

        frame = 2;
        damageBuffer = -1;
    }

    public void draw(SpriteBatch sb)
    {
        AquamentusTexture = Texture2DStorage.getBossSpritesheet();

        if(damageBuffer < 0)
        {
            if (frame == 0)
            {
                sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

            }
            else if (frame == 1)
            {
                sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

            }
            else if (frame == 2)
            {
                sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);

            }
            else if (frame == 3)
            {
                sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);

            }
        } else
        {
            drawHurt(sb);
        }
        
    }

    public void drawHurt(SpriteBatch sb)
    {
        AquamentusTexture = Texture2DStorage.getBossSpritesheet();

        if (frame == 0)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame0Rectangle, Color.Cyan);

        }
        else if (frame == 1)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame1Rectangle, Color.SandyBrown);

        }
        else if (frame == 2)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame2Rectangle, Color.Cyan);

        }
        else if (frame == 3)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame3Rectangle, Color.SandyBrown);

        }
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 100, 128);

        if(damageBuffer >= 0)
        {
            damageBuffer--;
        }

        frame = (time % 2) + 2;

        if (facingDirections >= 7 && facingDirections != 8)
        {
            frame -= 2;
        }
        

    }
}