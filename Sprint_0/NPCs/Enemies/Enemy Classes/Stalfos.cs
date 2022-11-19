using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Stalfos : IEnemy
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
    private const int enemySpeed = 10;
    private EnemyManager man;

    private bool damaged;
    private int damageBuffer;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Stalfos(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 2;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateStalfosSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);

        bufferVals[2] = 50;

        damaged = false;
    }

    /*
     * Core methods to change Stalfos's state and draws/updates
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
        if (!damaged)
        {
            state.hurt(this);
            damaged = true;
            damageBuffer = 50;
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
        if(damaged == false)
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
        man.randomStateGenerator(this, 0, 4);
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

    public void shootProjectile()
    {
        throw new NotImplementedException();
    }
}