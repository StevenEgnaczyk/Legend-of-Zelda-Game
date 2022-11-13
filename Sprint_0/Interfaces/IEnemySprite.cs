using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public interface IEnemySprite
{

    void update(int xPos, int yPos);

    void draw(int frame, SpriteBatch sb);

    void drawDeath(int deadFrame, SpriteBatch sb, int xPos, int yPos);
}
