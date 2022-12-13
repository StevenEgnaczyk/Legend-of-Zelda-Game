using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class DaBossBaby : IEnemy
{
    /* Properties that change, the heart of the enemy*/
    public IEnemyState state { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }


    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 100;
    private const int width = 90;
    private const int enemySpeed = 2;
    private EnemyManager man;

    public DaBossBaby(EnemyManager manager, int startX, int startY)
    {
        state = new LeftMovingEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 5;

        randTime = 0;

        sprite = EnemySpriteFactory.instance.CreateDaBossBabySprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);


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
        if (randTime % 3 == 0)
        {
            IEnemy golfball1 = new AdamSandlerGolfBall(man, this, 0);
            IEnemy golfball2 = new AdamSandlerGolfBall(man, this, 1);
            IEnemy golfball3 = new AdamSandlerGolfBall(man, this, 2);
            IEnemy golfball4 = new AdamSandlerGolfBall(man, this, 3);
        }
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
        AudioStorage.GetSugeEffect().Play();
        MediaPlayer.Stop();
        man.removeEnemy(this);

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