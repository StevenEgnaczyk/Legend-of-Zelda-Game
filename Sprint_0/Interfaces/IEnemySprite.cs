using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public interface IEnemySprite
{
    public int damageBuffer { get;  set; }
    //required methods for interface

    void update(float xPos, float yPos, int facingDirections, int time);

    void draw(SpriteBatch sb);

    void drawHurt(SpriteBatch sb);

}
