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
    private const float enemySpeed = 20;
    private int timeUntilDeath;
    private EnemyManager man;

    private int fireballnum;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];
    private int bufferMax = 30;

    public AquamentusFireball(EnemyManager manager, IEnemy aquamentus, int fireballNum)
    {
        state = new LeftMovingEnemyState(this);
        xPos = aquamentus.xPos;
        yPos = aquamentus.yPos - (aquamentus.getHeight() / 2);

        sprite = EnemySpriteFactory.instance.CreateAquamentusFireballSprite();
        man = manager;

        fireballnum = fireballNum;
        randTime = 0;
        timeUntilDeath = 0;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        bufferVals[2] = bufferMax;
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
        timeUntilDeath++;
        if (Buffer.itemBuffer(bufferVals))
        {
            if(fireballnum != 1 && randTime % 2 == 0)
            {
                if(fireballnum == 0)
                {

                    state.moveUp(this);

                } else
                {

                    state.moveDown(this);

                }
            }  else
            {
                state.moveLeft(this);
            }

            sprite.update(xPos, yPos, state.facingDirection, randTime);
            randTime++;
            
            if(randTime == 150 || timeUntilDeath == 1000)
            {
                die();
            }
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

}