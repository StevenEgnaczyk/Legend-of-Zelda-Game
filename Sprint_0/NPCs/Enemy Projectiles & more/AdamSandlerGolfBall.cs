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
    private const float enemySpeed = 3;
    private int timeUntilDeath;
    private EnemyManager man;

    public AdamSandlerGolfBall(EnemyManager manager, IEnemy AdamSandler, int golfBallNum)
    {
        if (golfBallNum == 0)
        {
            state = new LeftMovingEnemyState(this);

        } else if (golfBallNum == 1)
        {
            state = new RightMovingEnemyState(this);

        } else if (golfBallNum == 2)
        {
            state = new DownMovingEnemyState(this);

        } else
        {
            state = new UpMovingEnemyState(this);
        }
        
        xPos = AdamSandler.xPos + (AdamSandler.getHeight() / 2);
        yPos = AdamSandler.yPos + (AdamSandler.getWidth() / 2);
        
        randTime = 0; 
        timeUntilDeath = 0;

        sprite = EnemySpriteFactory.instance.CreateAdamSandlerGolfBallSprite();
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
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
        if (timeUntilDeath == 800)
        {
            die();

        } else
        {
            randTime++;
            timeUntilDeath++;

            state.update();
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
