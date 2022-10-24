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
        //TO DO: hurts animation and pushback
    }

    public void die()
    {
        //TO DO: Death animation
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
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(frame, sb);
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