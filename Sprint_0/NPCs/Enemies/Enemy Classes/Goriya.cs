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
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const float enemySpeed = 1;
    private EnemyManager man;
    private IEnemy boomerang;

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
        state.hurt(this);
        sprite.damageBuffer = 50;
        AudioStorage.GetEnemyHit().Play();

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
        if(randTime % 3 == 0)
        {
            //time boomerang is out
            randTime = 500;
            boomerang = new GoriyaBoomerang(man, xPos, yPos, this);
            int facingDirection = state.facingDirection;
            state.idle(this);
            state.facingDirection = facingDirection;
        }
        
         
    }

    public void update()
    {
        state.update();
        sprite.update(xPos, yPos, state.facingDirection, randTime);
        
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(sb);       
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

    public float getSpeed()
    {
        return enemySpeed;
    }
    public bool damaged()
    {
        return (sprite.damageBuffer >= 0);
    }
}