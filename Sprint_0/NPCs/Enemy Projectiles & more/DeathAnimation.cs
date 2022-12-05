using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Data.Common;
using System.Reflection.Metadata;
public class DeathAnimation : IEnemy
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
    private const float enemySpeed = 0;
    private EnemyManager man;


    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public DeathAnimation(EnemyManager manager,IEnemy enemy)
    {
        xPos = enemy.xPos;
        yPos = enemy.yPos;

        sprite = EnemySpriteFactory.instance.CreateDeathSprite();
        randTime = 0;
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        bufferVals[2] = 30;
    }

    public void moveLeft() { }

    public void moveRight() { }

    public void moveUp() { }

    public void moveDown() { }

    public void hurt() { }

    public void idle() { }

    public void shootProjectile() { }

    public void die()
    {

        man.removeEnemy(this);
    }

    public void update()
    {
        if (Buffer.itemBuffer(bufferVals))
        {
            sprite.update(xPos, yPos, 0, 0);
            randTime++;

            if (randTime == 5)
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
