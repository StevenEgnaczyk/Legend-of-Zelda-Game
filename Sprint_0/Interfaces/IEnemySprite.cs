using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public interface IEnemySprite
{

    void update(int xPos, int yPos, int facingDirections, int time);

    void draw(SpriteBatch sb);

    void drawHurt(SpriteBatch sb);
}
