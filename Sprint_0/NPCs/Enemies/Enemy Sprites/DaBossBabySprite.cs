using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Security.Cryptography;

public class DaBossBabySprite : IEnemySprite
{
    public int damageBuffer{ get; set; }
    private Texture2D DaBossBabyTexture;
    private int frame;

    private Rectangle destinationRectangle;

    //Note: Projectiles shoots only on frame 0,1
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    //2 hp but only can take damage from bombs add animation but allow for everything to do damage

    public DaBossBabySprite(Texture2D spritesheet)
    {
        DaBossBabyTexture = spritesheet;

        destinationRectangle = new Rectangle(300, 400, 100, 128);

        frame0Rectangle = new Rectangle(3, 237, 45, 50);
        frame1Rectangle = new Rectangle(52, 237, 45, 50);
        frame2Rectangle = new Rectangle(100, 237, 45, 50);

        frame = 0;
    }

    public void draw(SpriteBatch sb)
    {
        DaBossBabyTexture = Texture2DStorage.getEnemySpritesheet();
        sb.Draw(DaBossBabyTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

    }

    public void drawHurt(SpriteBatch sb)
    {
        DaBossBabyTexture = Texture2DStorage.getEnemySpritesheet();
        sb.Draw(DaBossBabyTexture, this.destinationRectangle, this.frame0Rectangle, Color.Cyan);
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 145, 135);

        frame = facingDirections;

        if (time % 2 == 0) 
        {

            frame++;

        }
        
    }
}
