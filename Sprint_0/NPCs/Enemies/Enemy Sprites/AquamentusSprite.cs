using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

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

    public AquamentusSprite(Texture2D spritesheet)
    {
        AquamentusTexture = spritesheet;

        destinationRectangle = new Rectangle(300, 400, 100, 128);

        frame0Rectangle = new Rectangle(1, 11, 24, 32);
        frame1Rectangle = new Rectangle(26, 11, 24, 32);
        frame2Rectangle = new Rectangle(51, 11, 24, 32);
        frame3Rectangle = new Rectangle(76, 11, 24, 32);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        AquamentusTexture = Texture2DStorage.getBossSpritesheet();

        if (frame == 11)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }else if (frame == 12)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }else if (frame == 4 || frame == 8)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);

        }else if(frame == 5 || frame == 9)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);

        }
    }

    public void update(int xPos, int yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 100, 128);

        frame = facingDirections;

        if (time % 2 == 0) 
        {

            frame++;

        }
        
    }
}