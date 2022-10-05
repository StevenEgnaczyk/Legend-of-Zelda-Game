using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class StalfosSprite : IEnemySprite
{
    private Texture2D stalfosTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;


    public StalfosSprite(Texture2D spritesheet)
    {
        this.stalfosTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);
        this.frame0Rectangle = new Rectangle(1, 59, 16, 16);

    }

    public void draw(int frame, SpriteBatch sb)
    {
        float zero = 0.0F;
        if ((frame % 2) == 0)
        {
            stalfosTexture = Texture2DStorage.getEnemySpritesheet();
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White, zero, new Vector2(0,0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void update(int xPos, int yPos)
    {
        this.destinationRectangle = new Rectangle(xPos, yPos, 32, 32);
    }
}