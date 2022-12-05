using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class OldManSprite : IEnemySprite
{
    private Texture2D OldManTexture;

    private Rectangle destinationRectangle;
    private Rectangle frame0Rectangle;

    public OldManSprite(Texture2D spritesheet)
    {
        this.OldManTexture = spritesheet;

        this.destinationRectangle = new Rectangle(0, 0, 32, 32);
        this.frame0Rectangle = new Rectangle(132, 90, 16, 16);

    }

    public void draw(SpriteBatch sb)
    {
        OldManTexture = Texture2DStorage.GetOldManSpriteSheet();
        sb.Draw(OldManTexture, this.destinationRectangle, this.frame0Rectangle, Color.White);
    }

    public void drawHurt(SpriteBatch sb)
    {
        //Cannot be damaged so no hurt drawn
    }

    public void update(float xPos, float yPos, int facingDirection, int time)
    {
        this.destinationRectangle = new Rectangle((int)xPos, (int)yPos, 64, 64);
    }
}