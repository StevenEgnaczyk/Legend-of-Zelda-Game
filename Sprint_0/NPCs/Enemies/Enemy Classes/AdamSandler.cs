using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class AdamSandler : IEnemy
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
    private const int enemySpeed = 100;
    private EnemyManager man;
    private bool damaged;
    private int damageBuffer;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public AdamSandler(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = 600;
        yPos = 484;
        health = 5;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateAdamSandlerSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);

        bufferVals[2] = 50;
        damaged = false;
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

    public void shootProjectile()
    {
        IEnemy golfball1 = new AdamSandlerGolfBall(man, this, 0);
        IEnemy golfball2 = new AdamSandlerGolfBall(man, this, 1);
        IEnemy golfball3 = new AdamSandlerGolfBall(man, this, 2);
        IEnemy golfball4 = new AdamSandlerGolfBall(man, this, 3);

    }

    public void hurt()
    {
        if (!damaged)
        {
            state.hurt(this);
            damaged = true;
            damageBuffer = 50;
            AudioStorage.GetEnemyHit().Play();
        }

        if (health == 0)
        {
            die();
        }
    }

    public void die()
    {
        IEnemy deathAnimation = new DeathAnimation(man, this);
        AudioStorage.GetEnemyDie().Play();
        man.removeEnemy(this);

    }

    public void update()
    {
     
        if (Buffer.itemBuffer(bufferVals))
        {
            

            state.update();
            sprite.update(xPos, yPos, state.facingDirection, randTime);
            
        }
        if (damageBuffer > 0)
        {
            damageBuffer--;
            if (damageBuffer == 0)
            {
                damaged = false;
            }
        }
    }

    public void draw(SpriteBatch sb)
    {
        if (damaged == false)
        {
            sprite.draw(sb);
        }
        else
        {
            sprite.drawHurt(sb);
        }
    }

    public void changeToRandState()
    {
        man.randomStateGenerator(this, 0, 7);
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