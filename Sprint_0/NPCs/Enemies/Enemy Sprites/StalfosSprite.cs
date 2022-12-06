using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class StalfosSprite : IEnemySprite
{
    private Texture2D stalfosTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;
    public int damageBuffer { get; set; }

    public StalfosSprite(Texture2D spritesheet)
    {
        frame = 0;
        damageBuffer = -1;
        stalfosTexture = spritesheet;
        destinationRectangle = new Rectangle(0, 0, 32, 32);
        frame0Rectangle = new Rectangle(1, 59, 16, 16);

    }

    public void draw(SpriteBatch sb)
    {
        stalfosTexture = Texture2DStorage.getEnemySpritesheet();
        float zero = 0.0F;

        if(damageBuffer < 0)
        {
            if (frame == 0)
            {
                sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

            }
            else
            {
                sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

            }
        } else
        {
            drawHurt(sb);
        }
        
    }
    public void drawHurt(SpriteBatch sb)
    {
        stalfosTexture = Texture2DStorage.getEnemySpritesheet();
        float zero = 0.0F;

        if (frame == 0)
        {
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.SandyBrown);

        }
        else
        {
            sb.Draw(this.stalfosTexture, this.destinationRectangle, this.frame0Rectangle, Color.Cyan, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

        if (damageBuffer >= 0)
        {
            damageBuffer--;
        }

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