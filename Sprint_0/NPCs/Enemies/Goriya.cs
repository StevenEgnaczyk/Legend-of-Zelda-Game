using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Goriya : IEnemy
{
    /* Properties that change, the heart of the enemy*/
    public EnemyState state {  get;  set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const int enemySpeed = 3;
    private SpriteBatch _spriteBatch;
    private EnemyManager man;
    

    /* Buffer properties*/
    private int frame;
    private int bufferIndex;
    private int bufferMax = 20;
    private int deadBuffer;
    private int deadBufferMax = 30;
    private int maxFrame = 4;
    private int deadFrame = 0;

    public Goriya(SpriteBatch sb, EnemyManager manager, int startX, int startY)
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        xPos = startX;
        yPos = startY;

        sprite = EnemySpriteAndStateFactory.instance.CreateGoriyaSprite();
        _spriteBatch = sb;
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        health = 60;
        deadBuffer = 0;
        bufferIndex = 0;
        frame = 0;
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

    public void hurt()
    {
        health--;
    }

    public void die()
    {
        AudioStorage.GetEnemyDie().Play();
        man.removeEnemy(this);
    }

    public void update()
    {
        sprite.update(xPos, yPos);
        if (this.frame == 0)
        {
            this.bufferIndex++;
        }
        else
        {
            this.bufferIndex += 2;
        }

        if (this.bufferIndex == this.bufferMax)
        {
            state.moveLeft(this);
            this.bufferIndex = 0;
            this.frame++;
            if (this.frame == 4)
            {
                this.frame = 0;
            }
        }

        //death Animation playthrough
        if (health <= 0)
        {
            if (deadFrame == 0)
            {
                deadBuffer++;
            }
            else
            {
                deadBuffer += 5;
            }

            if (deadBuffer == deadBufferMax)
            {
                deadBuffer = 0;
                deadFrame++;
                if (deadFrame == maxFrame)
                {
                    //fix problem with crash when removing enemy while looping through list in enemy manager
                    die();
                    deadFrame = 0;
                }
            }
        }
    }

    public void draw(SpriteBatch sb)
    {
        if (health >= 0)
        {
            sprite.draw(this.frame, sb);
        }
        else
        {
            sprite.drawDeath(deadFrame, sb);
        }
    }

    /*
     * Getter methods
     */
    public int getEnemyUp()
    {
        return state.up;
    }

    public int getEnemyLeft()
    {
        return state.left;
    }

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