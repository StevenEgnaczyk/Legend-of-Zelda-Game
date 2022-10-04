using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class GoriyaSprite : IEnemySprite
{
    private Texture2D goriyaTexture;

    private Rectangle destinationRectantgle;

    private Rectangle walk0Rectangle;
    private Rectangle walk1Rectangle;
    private Rectangle upRectangle;
    private Rectangle downRectangle;

    public int left { get; set; }
    public int up { get; set; }

    private bool flip;

    public GoriyaSprite(Texture2D spritesheet)
    {
        this.goriyaTexture = spritesheet;

        walk0Rectangle = new Rectangle(273, 11, 16, 16);
        walk1Rectangle = new Rectangle(256, 11, 16, 16);
        upRectangle = new Rectangle(239, 11, 16, 16);
        downRectangle = new Rectangle(222, 11, 16, 16);

        flip = false;

    }

    public void getState(int left, int up)
    {

    }

    public void draw(int frame, SpriteBatch sb)
    {
        
        if (this.flip)
        {
            drawFlipped(this.left, this.up, this.destinationRectantgle, sb);

        } else
        {
            drawNormal(this.left, this.up, this.destinationRectantgle, sb);

        }
        this.flip = !this.flip;
    }

    public  void drawNormal(int left, int up, Rectangle destination, SpriteBatch sb)
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
            sb.Draw(this.goriyaTexture, destination, this.walk0Rectangle, Color.White, zero, new Vector2(0,0), SpriteEffects.FlipHorizontally, zero);

        }
        else if(left == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.walk1Rectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else if (up == 1)
        {
            sb.Draw(this.goriyaTexture, destination, this.upRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
        else  if (up == 2)
        {
            sb.Draw(this.goriyaTexture, destination, this.downRectangle, Color.White, zero, new Vector2(0, 0), SpriteEffects.FlipHorizontally, zero);

        }
    }

    public void update(int xPos, int yPos)
    {

        flip = !this.flip;
        destinationRectantgle = new Rectangle(xPos, yPos, 32, 32);
    }
}