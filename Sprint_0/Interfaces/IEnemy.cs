using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemy
{
    public int xPos { get; set; }
    public int yPos { get; set; }

    void draw(SpriteBatch _spriteBatch);
    void update();
    void moveUp();
    void moveDown();
    void moveLeft();
    void moveRight();
    void hurt();
    int getEnemyUp();
    int getEnemyLeft();

}
