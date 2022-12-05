using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class KeeseSprite : IEnemySprite
{
    private Texture2D keeseTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    private int frame;

    public KeeseSprite (Texture2D spritesheet)
    {
        keeseTexture = spritesheet;

        destinationRectangle = new Rectangle(0, 0, 32, 32);

        frame0Rectangle = new Rectangle(183, 11, 16, 16);
        frame1Rectangle = new Rectangle(200, 11, 16, 16);

    }

    public void draw(SpriteBatch sb)
    {
        keeseTexture = Texture2DStorage.getEnemySpritesheet();

        if (frame  == 0)
        {
            sb.Draw(keeseTexture, destinationRectangle, frame0Rectangle, Color.White);

        } else
        {
            sb.Draw(keeseTexture, destinationRectangle, frame1Rectangle, Color.White);

        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Only has 1 health so no damaged state drawn
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

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