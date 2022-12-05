using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GelSprite : IEnemySprite
{
    private Texture2D gelTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    //1 hp no damaged animation
    public GelSprite(Texture2D spritsheet)
    {
        gelTexture = spritsheet;
        frame = 0;

        destinationRectangle = new Rectangle(0, 0, 32, 32);
        frame0Rectangle = new Rectangle(1, 16, 8, 8);
        frame1Rectangle = new Rectangle(11, 15, 6, 9);

    }

    public void draw(SpriteBatch sb)
    {
        if (frame == 0)
        {
            gelTexture = Texture2DStorage.getEnemySpritesheet();
            sb.Draw(this.gelTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.gelTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Only has 1 health damage not drawn
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 32, 32);

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