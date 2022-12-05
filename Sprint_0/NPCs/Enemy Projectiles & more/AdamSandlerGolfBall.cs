using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Data.Common;
using System.Reflection.Metadata;
public class AdamSandlerGolfBall : IEnemy
{
    
    public IEnemyState state { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    //8x8 on spritesheet
    private const int height = 16;
    private const int width = 16;
    private const float enemySpeed = 30;
    private int timeUntilDeath;
    private EnemyManager man;
    private int golfBall;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];
    private int bufferMax = 40;
    private int[] limit = new int[4];

    public AdamSandlerGolfBall(EnemyManager manager, IEnemy AdamSandler, int golfBallNum)
    {
        state = new LeftMovingEnemyState(this);
        xPos = AdamSandler.xPos + (AdamSandler.getHeight() / 2);
        yPos = AdamSandler.yPos + (AdamSandler.getWidth() / 2);
        randTime = 1000;
        timeUntilDeath = 0;
        golfBall = golfBallNum;
        sprite = EnemySpriteFactory.instance.CreateAdamSandlerGolfBallSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        bufferVals[2] = bufferMax;
    }

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
            
            if(golfBall == 0 && randTime % 2 == 0)
            {
                state.moveUp(this);
            }else if(golfBall == 1 && randTime % 2 == 0)
            {
                state.moveDown(this);
            }
            else if(golfBall == 2 && randTime % 2 == 0)
            {
                state.moveLeft(this);
            }else if(golfBall == 3 && randTime % 2 == 0)
            {
                state.moveRight(this);
            }
            randTime++;
            if (timeUntilDeath == 200)
            {
                die();
            }
            sprite.update(xPos, yPos, state.facingDirection, randTime);           
        }
        
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(sb);
    }

    public void changeToRandState() {
        //none
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

}
