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

    public GoriyaSprite(Texture2D spritesheet)
    {
        goriyaTexture = spritesheet;

        destinationRectantgle = new Rectangle(0, 0, 32, 32);
        walk0Rectangle = new Rectangle(273, 11, 16, 16);
        walk1Rectangle = new Rectangle(256, 11, 16, 16);
        upRectangle = new Rectangle(239, 11, 16, 16);
        downRectangle = new Rectangle(222, 11, 16, 16);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        goriyaTexture = Texture2DStorage.getEnemySpritesheet();

        if (this.flip)
        {

            drawFlipped(sb);

        }
        else
        {

            drawNormal(sb);

        }


    }

    public void drawNormal(SpriteBatch sb)
    {

        if (frame == 4)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, walk0Rectangle, Color.White);

        }
        else if (frame == 5 || frame == 7)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, walk1Rectangle, Color.White);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, upRectangle, Color.White);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, downRectangle, Color.White);

        }
    }

    public void drawFlipped(SpriteBatch sb)
    {
        float zero = 0.0F;
        if (frame == 8)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, walk0Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 11 || frame == 9)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, walk1Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 14 || frame == 2)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, upRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (frame == 13 || frame == 1)
        {
            sb.Draw(goriyaTexture, destinationRectantgle, downRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void update(int xPos, int yPos, int facingDirections, int time)
    {
        destinationRectangle = new Rectangle(xPos, yPos, 64, 64);

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
