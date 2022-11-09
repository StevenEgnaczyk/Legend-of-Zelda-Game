using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class BladeTrap : IEnemy
{
    /* Properties that change, the heart of the enemy*/
    public IEnemyState state {  get;  set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }


    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const int enemySpeed = 3;
    private EnemyManager man;

    /* No buffer properties as it is not animated*/

    public BladeTrap(EnemyManager manager, int startX, int startY)
    {
        state = new IdleEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 1000;

        sprite = EnemySpriteFactory.instance.CreateBladeTrapSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
    }

    /*
     * Core methods to change BaldeTraps's state and draw/update
     */
    public void moveLeft()
    {
        state.moveLeft(this);
    }

    public void moveRight()
    {
        state.moveRight(this);
    }

    public void moveUp()
    {
        state.moveUp(this);
    }

    public void moveDown()
    {
        state.moveDown(this);
    }

    public void idle()
    {
        state.idle(this);
    }

    public void hurt()
    {
        //do nothing, cannot die
    }

    public void update()
    {
    
        sprite.update(xPos, yPos, state.facingDirection, 0);

    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(sb);
    }

    public void changeToRandState() { }

    /*
     * Getter methods
     */

    public int getHeight()
    {
        return height;
    }

    public int getWidth()
    {
        return width;
    }

    public int getSpeed()
    {
        return enemySpeed;
    }
}
