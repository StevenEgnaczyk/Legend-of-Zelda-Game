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

    public KeeseSprite (Texture2D spritesheet)
    {
        this.keeseTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        this.frame0Rectangle = new Rectangle(183, 11, 16, 16);
        this.frame1Rectangle = new Rectangle(200, 11, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        if ((frame % 2) == 0)
        {
            sb.Draw(this.keeseTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        } else
        {
            sb.Draw(this.keeseTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

    public void update(int xPos, int yPos) 
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
    }
}