using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class WallmasterSprite : IEnemySprite
{
    private Texture2D wallmasterTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    private int frame;
    public int damageBuffer { get; set; }

    public WallmasterSprite(Texture2D spritsheet)
    {
        wallmasterTexture = spritsheet;
        damageBuffer = -1;

        destinationRectangle = new Rectangle(0, 0, 32, 32);
        frame0Rectangle = new Rectangle(393, 11, 16, 16);
        frame1Rectangle = new Rectangle(410, 11, 16, 16);
    }

    public void draw(SpriteBatch sb)
    {
        wallmasterTexture = Texture2DStorage.getEnemySpritesheet();
        if (frame == 0)
        {
            sb.Draw(wallmasterTexture, destinationRectangle, frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(wallmasterTexture, destinationRectangle, frame1Rectangle, Color.White);

        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Only has 1 health so hurt state not drawn
    }
    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

        if (0 <= (time % 40) && (time % 40) < 20)
        {
            frame = 0;

        }
        else
        {
            frame = 1;

        }
    }
}