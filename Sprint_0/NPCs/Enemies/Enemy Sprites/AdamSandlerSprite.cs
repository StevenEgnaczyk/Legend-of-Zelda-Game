using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class AdamSandlerSprite : IEnemySprite
{
    private Texture2D adamSandlerTexture;
    private int frame;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;

    public AdamSandlerSprite(Texture2D spritesheet)
    {
        frame = 0;
        adamSandlerTexture = spritesheet;
        destinationRectangle = new Rectangle(0, 0, 32, 32);
        frame0Rectangle = new Rectangle(163, 238, 17, 27);

    }

    public void draw(SpriteBatch sb)
    {
        adamSandlerTexture = Texture2DStorage.getEnemySpritesheet();
        float zero = 0.0F;

        if (frame == 0)
        {
            sb.Draw(this.adamSandlerTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);

        }
        else
        {
            sb.Draw(this.adamSandlerTexture, this.destinationRectangle, this.frame0Rectangle, Color.White, zero, new Vector2(0,0), SpriteEffects.FlipHorizontally, zero);

        }
    }
    public void drawHurt(SpriteBatch sb)
    {
        adamSandlerTexture = Texture2DStorage.getEnemySpritesheet();
        float zero = 0.0F;

        if (frame == 0)
        {
            sb.Draw(this.adamSandlerTexture, this.destinationRectangle, this.frame0Rectangle, Color.SandyBrown);

        }
        else
        {
            sb.Draw(this.adamSandlerTexture, this.destinationRectangle, this.frame0Rectangle, Color.Cyan, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void update(float xPos, float yPos, int facingDirections, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);

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