using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Data.Common;
using System.Reflection.Metadata;
public class AquamentusFireball : IEnemy
{

    public IEnemyState state { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 16;
    private const int width = 16;
    private const float enemySpeed = 2;
    private int timeUntilDeath;
    private EnemyManager man;

    private int fireballnum;


    public AquamentusFireball(EnemyManager manager, IEnemy aquamentus, int fireballNum)
    {
        state = new LeftMovingEnemyState(this);
        xPos = aquamentus.xPos - (aquamentus.getSpeed() / 2);
        yPos = aquamentus.yPos + (aquamentus.getHeight() / 2);

        sprite = EnemySpriteFactory.instance.CreateAquamentusFireballSprite();
        man = manager;

        fireballnum = fireballNum;
        randTime = 0;
        timeUntilDeath = 0;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
    }

    public void moveLeft()
    {
        state.moveLeft(this);
    }

    public void moveRight() { }

    public void moveUp()
    {
        state.moveUp(this);
    }

    public void moveDown()
    {
        state.moveDown(this);
    }

    public void hurt() { }

    public void idle() { }

    public void shootProjectile() { }

    public void die()
    {
        man.removeEnemy(this);
    }

    public void update()
    {
        if (timeUntilDeath == 800)
        {
            die();

        }
        else
        {
            randTime++;
            timeUntilDeath++;

            if(fireballnum == 0)
            {
                yPos--;

            } else if (fireballnum == 2)
            {
                yPos++;

            }

            state.update();
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

    public float getSpeed()
    {
        return enemySpeed;
    }
    public bool damaged()
    {
        return false;
    }

}