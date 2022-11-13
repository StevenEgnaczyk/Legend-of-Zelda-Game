using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class StalfosSprite : IEnemySprite
{
    private Texture2D stalfosTexture;
    private Texture2D deathTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    private Rectangle deathRectangle;
    //2 hp implement damaged animation

    public StalfosSprite(Texture2D spritesheet)
    {
        this.stalfosTexture = spritesheet;
        this.destinationRectangle = new Rectangle(0, 0, 32, 32);
        this.frame0Rectangle = new Rectangle(1, 59, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        stalfosTexture = Texture2DStorage.getEnemySpritesheet();
        float zero = 0.0F;
        if ((frame % 2) == 0)
        {
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White, zero, new Vector2(0,0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos)
    {
        deathTexture = Texture2DStorage.GetDeathSpriteSheet();
        deathRectangle = ItemRectStorage.getDeathAnimation(deadFrame);
        destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
        sb.Draw(deathTexture, destinationRectangle, deathRectangle, Color.White);

    }
    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 64, 64);
    }
}