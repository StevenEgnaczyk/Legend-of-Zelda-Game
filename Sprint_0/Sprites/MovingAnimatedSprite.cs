using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

public class MovingAnimatedSprite : ISprite
{
    public Texture2D movingMario { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int currentFrame;
    private int totalFrames;

    private int delayCounter;
    private int delayMax;

    private int mario_x_pos;

    public MovingAnimatedSprite(ContentManager c, int rows, int columns)
	{
        movingMario = c.Load<Texture2D>("movingMario2");
        Rows = rows;
        Columns = columns;
        currentFrame = 0;
        totalFrames = Rows * Columns;
        delayCounter = 0;
        delayMax = 10;
        mario_x_pos = 250;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        int width = movingMario.Width / Columns;
        int height = movingMario.Height / Rows;
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle(mario_x_pos, (int)location.Y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(movingMario, destinationRectangle, sourceRectangle, Color.White);
        Update();
        spriteBatch.End();

    }

    public void Update()
    {
        delayCounter++;

        if (delayCounter == delayMax)
        {
            delayCounter = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        mario_x_pos++;
        if (mario_x_pos > 800)
        {
            mario_x_pos = 0;
        }
    }

        public void Draw(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}
