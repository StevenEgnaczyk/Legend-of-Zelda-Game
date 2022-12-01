using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Data.Common;
using System.Reflection.Metadata;
public class GoriyaBoomerang : IEnemy
{
    
    public IEnemyState state { get; set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    //8x8 on spritesheet
    private const int height = 16;
    private const int width = 16;
    private const int enemySpeed = 30;
    private int timeUntilDeath;
    private EnemyManager man;
    private int startXPos;
    private int startYPos;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];
    private int bufferMax = 40;
    private int[] limit = new int[4];

    public GoriyaBoomerang(EnemyManager manager, int startX, int startY, IEnemy goriya)
    {
        state = new LeftMovingEnemyState(this);
        getGoriyaDirection(goriya);
        xPos = goriya.xPos + (goriya.getHeight() / 2);
        yPos = goriya.yPos + goriya.getWidth() / 2;
        startXPos = xPos;
        startYPos = yPos;
        randTime = 1000;
        timeUntilDeath = 0;
        /*
         * [x limit right, x limit left, y limit down, y limit up]
         */
        limit[0] = xPos + 400;
        limit[1] = xPos - 400;
        limit[2] = yPos + 400;
        limit[3] = yPos - 400;

        sprite = EnemySpriteFactory.instance.CreateGoyiraBoomerangSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        bufferVals[2] = bufferMax;
    }

    private void getGoriyaDirection(IEnemy goriya)
    {
        if (goriya.state.facingDirection == 14 || goriya.state.facingDirection == 2)
        {
            state = new UpMovingEnemyState(this);
        }
        else if (goriya.state.facingDirection == 13 || goriya.state.facingDirection == 1)
        {
            state = new DownMovingEnemyState(this);
        }
        else if (goriya.state.facingDirection == 11 || goriya.state.facingDirection == 8)
        {
            state = new LeftMovingEnemyState(this);
        }
        else if (goriya.state.facingDirection == 7 || goriya.state.facingDirection == 4)
        {
            state = new RightMovingEnemyState(this);
        }
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
            state.update();
            sprite.update(xPos, yPos, state.facingDirection, randTime);
            if (xPos >= limit[0])
            {
                //change right to left
                state.moveLeft(this);
            }
            else if(xPos <= limit[1])
            {
                //change left to right
                state.moveRight(this);
            }
            else if(yPos >= limit[2])
            {
                //change down to up
                state.moveUp(this);
            }
            else if(yPos <= limit[3])
            {
            //change up to down
            state.moveDown(this);
            }
            else if((startXPos == xPos && startYPos == yPos) || timeUntilDeath == 500)
            {
                die();
            }          
        }
        
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(sb);
    }

    public void changeToRandState() {
        //empty so boomerang doesnt change directions randomly
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
