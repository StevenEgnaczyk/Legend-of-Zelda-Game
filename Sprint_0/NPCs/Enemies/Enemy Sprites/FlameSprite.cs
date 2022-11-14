using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class FlameSprite : IEnemySprite
{
    private Texture2D OldManTexture;


    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;

    //cant die add large number of hp so they cant die

    public FlameSprite(Texture2D spritesheet)
    {
        this.OldManTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);

        frame0Rectangle = new Rectangle(52, 11, 16, 16);

        frame1Rectangle = new Rectangle(68, 11, 16, 16);
    }

    public void draw(int frame, SpriteBatch sb)
    {
        if ((frame % 2) == 0)
        {
            OldManTexture = Texture2DStorage.GetOldManSpriteSheet();
            sb.Draw(this.OldManTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.OldManTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }
    }

        public void drawDeath(int deadFrame, SpriteBatch sb)
    {
        throw new NotImplementedException();
    }
    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 64, 64);
    }

    public void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos)
    {
        throw new NotImplementedException();
    }
}