using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class NonMovingAnimatedSprite : ISprite
{
    public Texture2D movingMario { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int currentFrame;
    private int totalFrames;

    private int delayCounter;
    private int delayMax;

    public NonMovingAnimatedSprite(ContentManager c, int rows, int columns)
    {
        movingMario = c.Load<Texture2D>("movingMario2");
        Rows = rows;
        Columns = columns;
        currentFrame = 0;
        totalFrames = Rows * Columns;
        delayCounter = 0;
        delayMax = 10;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 location)
	{
        int width = movingMario.Width / Columns;
        int height = movingMario.Height / Rows;
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(movingMario, destinationRectangle, sourceRectangle, Color.White);
        Update();
        spriteBatch.End();

    }

	public void Update()
	{
        delayCounter++;
        Debug.WriteLine(delayCounter);
        if (delayCounter == delayMax)
        {
            delayCounter = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
    }
}
