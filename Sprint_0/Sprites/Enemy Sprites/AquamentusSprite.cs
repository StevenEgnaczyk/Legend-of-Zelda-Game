using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class AquamentusSprite : IEnemySprite
{
    private Texture2D AquamentusTexture;
    private Texture2D deathTexture;
    private Rectangle destinationRectangle;

    //Note: Projectiles shoots only on frame 1
    private Rectangle frame0Rectangle;
    private Rectangle frame1Rectangle;
    private Rectangle frame2Rectangle;
    private Rectangle frame3Rectangle;
    private Rectangle deathRectangle;
    //2 hp but only can take damage from bombs add animation but allow for everything to do damage

    public AquamentusSprite(Texture2D spritesheet)
    {
        this.AquamentusTexture = spritesheet;

        this.destinationRectangle = new Rectangle(300, 400, 48, 64);

        this.frame0Rectangle = new Rectangle(1, 11, 24, 32);
        this.frame1Rectangle = new Rectangle(26, 11, 24, 32);
        this.frame2Rectangle = new Rectangle(51, 11, 24, 32);
        this.frame3Rectangle = new Rectangle(76, 11, 24, 32);
    }

    public void draw(int frame, SpriteBatch sb)
    {
        AquamentusTexture = Texture2DStorage.getBossSpritesheet();

        if (frame % 4 == 0)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }else if (frame % 4 == 1)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame1Rectangle, Color.White);

        }else if (frame % 4 == 2)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame2Rectangle, Color.White);

        }else if(frame % 4 == 3)
        {
            sb.Draw(AquamentusTexture, this.destinationRectangle, this.frame3Rectangle, Color.White);

        }
    }

    public void drawDeath(int deadFrame, SpriteBatch sb)
    {
        deathTexture = Texture2DStorage.GetDeathSpriteSheet();
        deathRectangle = ItemRectStorage.getDeathAnimation(deadFrame);
        sb.Draw(deathTexture, destinationRectangle, deathRectangle, Color.White);
    }
    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 48, 64);
        
    }
}