using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GoriyaSprite : IEnemySprite
{
    private Texture2D goriyaTexture;
    private Texture2D deathTexture;
    private Rectangle destinationRectantgle;

    private Rectangle walk0Rectangle;
    private Rectangle walk1Rectangle;
    private Rectangle upRectangle;
    private Rectangle downRectangle;
    private Rectangle deathRectangle;

    public int left = 1;
    public int up = 1;

    private bool flip;
    private int frame;
    private int bufferIndex;
    private int bufferMax = 40;
    //3 hp implement damage animation
    public GoriyaSprite(Texture2D spritesheet)
    {
        this.goriyaTexture = spritesheet;
        this.destinationRectantgle = new Rectangle(0, 0, 32, 32);
        this.walk0Rectangle = new Rectangle(273, 11, 16, 16);
        this.walk1Rectangle = new Rectangle(256, 11, 16, 16);
        this.upRectangle = new Rectangle(239, 11, 16, 16);
        this.downRectangle = new Rectangle(222, 11, 16, 16);

        this.flip = false;
        this.bufferIndex = 0;
        this.frame = 0;
    }

    public void getState(int left, int up)
    {

    }

    public void draw(int frame, SpriteBatch sb)
    {
        goriyaTexture = Texture2DStorage.getEnemySpritesheet();
        //sb.DrawInventory(this.goriyaTexture, this.destinationRectantgle, this.walk0Rectangle, Color.White);
        if (this.flip)
        {
            drawFlipped(this.left, this.up, this.destinationRectantgle, sb);

        }
        else
        {
            drawNormal(this.left, this.up, this.destinationRectantgle, sb);

        }


    }

    public void drawNormal(int left, int up, Rectangle destination, SpriteBatch sb)
    {

        if (left == 1)
        {
            sb.Draw(this.goriyaTexture, destination, this.walk0Rectangle, Color.White);

        }
        else if (left == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.walk1Rectangle, Color.White);

        }
        else if (up == 1)
        {
            sb.Draw(this.goriyaTexture, destination, this.upRectangle, Color.White);

        }
        else if (up == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.downRectangle, Color.White);

        }
    }

    public void drawFlipped(int left, int up, Rectangle destination, SpriteBatch sb)
    {
        float zero = 0.0F;
        if (left == 1)
        {
            sb.Draw(this.goriyaTexture, destination, this.walk0Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (left == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.walk1Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (up == 1)
        {
            sb.Draw(this.goriyaTexture, destination, this.upRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (up == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.downRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos)
    {
        deathTexture = Texture2DStorage.GetDeathSpriteSheet();
        deathRectangle = ItemRectStorage.getDeathAnimation(deadFrame);
        destinationRectantgle = new Rectangle(xPos, yPos, 32, 32);
        sb.Draw(deathTexture, destinationRectantgle, deathRectangle, Color.White);

    }
    public void update(int xPos, int yPos)
    {
        if (this.frame == 0)
        {
            this.bufferIndex++;
        }
        else
        {
            this.bufferIndex += 2;
        }

        if (this.bufferIndex == this.bufferMax)
        {
            this.bufferIndex = 0;
            flip = !this.flip;
            this.frame++;
            if (this.frame == 4)
            {
                this.frame = 0;
            }
        }


        destinationRectantgle = new Rectangle(xPos, yPos, 64, 64);
    }
}
