using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemy
{
    //required type properties
    public IEnemyState state { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    //required methods for interface
    void draw(SpriteBatch _spriteBatch);
    void update();
    void moveUp();
    void moveDown();
    void moveLeft();
    void moveRight();
    void idle();
    void hurt();

    void die();
    void shootProjectile();
    void changeToRandState();

    int getHeight();
    int getWidth();
    float getSpeed();
    bool damaged();

}
