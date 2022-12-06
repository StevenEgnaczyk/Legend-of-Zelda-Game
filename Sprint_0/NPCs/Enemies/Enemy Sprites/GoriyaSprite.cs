using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GoriyaSprite : IEnemySprite
{
    private Texture2D goriyaTexture;

    private Rectangle destinationRectangle;

    private Rectangle walk0Rectangle;
    private Rectangle walk1Rectangle;
    private Rectangle upRectangle;
    private Rectangle downRectangle;

    private bool flip;
    private int frame;

    public int damageBuffer { get; set; }

    public GoriyaSprite(Texture2D spritesheet)
    {
        goriyaTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 32, 32);
        walk0Rectangle = new Rectangle(273, 11, 16, 16);
        walk1Rectangle = new Rectangle(256, 11, 16, 16);
        upRectangle = new Rectangle(239, 11, 16, 16);
        downRectangle = new Rectangle(222, 11, 16, 16);

        frame = 0;
        damageBuffer = -1;
    }

    public void draw(SpriteBatch sb)
    {
        if (this.flip && damageBuffer < 0)
        {

            drawFlipped(sb);

        }
        else if (!flip && damageBuffer < 0)
        {

            drawNormal(sb);

        } else
        {

            drawHurt(sb);

        }


    }

    public void drawHurt(SpriteBatch sb)
    {
        if (this.flip)
        {

            drawHurtFlipped(sb);

        }
        else
        {

            drawHurtNormal(sb);

        }
    }

    public void drawNormal(SpriteBatch sb)
    {

        if (frame == 4)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk0Rectangle, Color.White);

        }
        else if (frame == 5 || frame == 7)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk1Rectangle, Color.White);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectangle, upRectangle, Color.White);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectangle, downRectangle, Color.White);

        }
    }

    public void drawFlipped(SpriteBatch sb)
    {
        float zero = 0.0F;
        if (frame == 8)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk0Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 11 || frame == 9)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk1Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectangle, upRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectangle, downRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void drawHurtFlipped(SpriteBatch sb)
    {
        float zero = 0.0F;
        if (frame == 8)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk0Rectangle, Color.Blue, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 11 || frame == 9)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk1Rectangle, Color.Lime, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectangle, upRectangle, Color.Blue, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectangle, downRectangle, Color.Lime, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void drawHurtNormal(SpriteBatch sb)
    {
        if (frame == 4)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk0Rectangle, Color.Blue);

        }
        else if (frame == 5 || frame == 7)
        {
            sb.Draw(goriyaTexture, destinationRectangle, walk1Rectangle, Color.Lime);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectangle, upRectangle, Color.Blue);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectangle, downRectangle, Color.Lime);

        }
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

        if(damageBuffer >= 0)
        {
            damageBuffer--;
        }

        frame = facingDirections;

        if (frame == 8 || frame == 11)
        {
            flip = true;
        }
        else if (frame > 11 || frame < 3)
        {
            flip = (time % 2 == 0);
        } else
        {
            flip = false;
        }

        if (frame == 4 || frame == 8)
        {
            if(time % 2 == 0)
            {
                frame++;
            }
        }
        
    }
}
