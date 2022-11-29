using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Goriya : IEnemy
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
    private const int enemySpeed = 10;
    private EnemyManager man;
    private IEnemy boomerang;
    private bool damaged;
    private int damageBuffer;
    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Goriya(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        
        xPos = startX;
        yPos = startY;
        
        health = 3;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateGoriyaSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        
        bufferVals[2] = 50;
        damaged = false;
        
    }

     /*
     * Core methods to change Goriya's state and draws/updates
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

    public void shootProjectile()
    {
        //time boomerang is out
        randTime = 25;
        boomerang = new GoriyaBoomerang(man, xPos, yPos, this);
        int facingDirection = state.facingDirection;
        state.idle(this);
        state.facingDirection = facingDirection;
         
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
        man.randomStateGenerator(this, 0, 5);
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