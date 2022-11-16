using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemy
{
    public IEnemyState state { get; set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    void draw(SpriteBatch _spriteBatch);
    void update();
    void moveUp();
    void moveDown();
    void moveLeft();
    void moveRight();
    void idle();
    void hurt();
    void shootProjectile();
    void changeToRandState();

    int getHeight();
    int getWidth();
    int getSpeed();

}
