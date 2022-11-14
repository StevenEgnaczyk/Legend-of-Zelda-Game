using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Wallmaster : IEnemy
{
    /* Properties that change, the heart of the enemy*/
    public IEnemyState state {  get;  set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 48;
    private const int width = 48;
    private const int enemySpeed = 3;
    private EnemyManager man;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Wallmaster(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 1;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateWallmasterSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);

        bufferVals[2] = 20;
    }

    /*
     * Core methods to change Wallmaster's state and draws/updates
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
        state.hurt(this);

        if (health == 0)
        {
            die();
        }
    }

    public void die()
    {
        sprite = EnemySpriteFactory.instance.CreateDeathSprite();
        AudioStorage.GetEnemyDie().Play();
        man.removeEnemy(this);

    }

    public void update()
    {
        if (Buffer.itemBuffer(bufferVals))
        {
            sprite.update(xPos, yPos, state.facingDirection, randTime);
        }
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