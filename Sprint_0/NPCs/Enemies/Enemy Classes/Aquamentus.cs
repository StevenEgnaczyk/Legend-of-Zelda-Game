using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Aquamentus : IEnemy
{
    /*
     * TO DO: Determine if aquamentus's state needs to be updated. 
     * /


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

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Aquamentus(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 3;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateAquamentusSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);

        bufferVals[2] = 20;
    }

    /*
     * Core methods to change Aquamentus's state and draw/update
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
        state.moveLeft(this); 
    }

    public void moveDown()
    {
        state.moveRight(this);
    }

    public void idle()
    {
        state.idle(this);
    }

    public void shootProjectile()
    {
        state.shootProjectile(this);
    }

    public void hurt()
    {
        state.hurt(this);
    }

    public void die()
    {
        //TO DO: death animation
        man.removeEnemy(this);
    }

    public void update()
    {
     
        if (Buffer.itemBuffer(bufferVals))
        {
            state.update();
            sprite.update(xPos, yPos, state.facingDirection, randTime);
            
        }
    }

    public void draw(SpriteBatch _spriteBatch)
    {
        sprite.draw(_spriteBatch);
    }

    public void changeToRandState()
    {
        man.randomStateGenerator(this, 2, 5);
    }


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