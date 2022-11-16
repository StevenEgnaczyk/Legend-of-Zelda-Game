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
    private const int enemySpeed = 5;
    private EnemyManager man;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Aquamentus(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = 600;
        yPos = 484;
        health = 3;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateAquamentusSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);

        bufferVals[2] = 50;
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

    public void moveUp() { }

    public void moveDown() { }

    public void idle()
    {
        state.idle(this);
    }

    public void shootProjectile()
    {
        IEnemy fireball1 = new AquamentusFireball(man, this, 0);
        IEnemy fireball2 = new AquamentusFireball(man, this, 1);
        IEnemy fireball3 = new AquamentusFireball(man, this, 2);

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
        IEnemy deathAnimation = new DeathAnimation(man, this);
        AudioStorage.GetEnemyDie().Play();
        man.removeEnemy(this);

    }

    public void update()
    {
     
        if (Buffer.itemBuffer(bufferVals))
        {
            if( xPos < 564)
            {
                
                state.moveRight(this);

            } else if (xPos > 704)
            {
                
                state.moveLeft(this);

            }

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