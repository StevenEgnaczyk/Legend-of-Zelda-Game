using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Stalfos : IEnemy
{
    /* Properties that change, the heart of the enemy*/
    public EnemyState state {  get;  set; }
    public int xPos { get; set; }
    public int yPos { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 48;
    private const int width = 48;
    private const int enemySpeed = 1;
    private SpriteBatch _spriteBatch;
    private EnemyManager man;

    /* Buffer properties*/
    private int bufferIndex;
    private int bufferMax = 20;
    private int frame;

    public Stalfos(SpriteBatch sb, EnemyManager manager, int startX, int startY)
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        xPos = startX;
        yPos = startY;

        sprite = EnemySpriteAndStateFactory.instance.CreateStalfosSprite();
        _spriteBatch = sb;
        man = manager;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
        
        frame = 0;
        bufferIndex = 0;
    }

    /*
     * Core methods to change Stalfos's state and draws/updates
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
       this.die();
    }

    public void die()
    {
        //TO DO: Death animation
        AudioStorage.GetEnemyDie().Play();
        man.removeEnemy(this);
    }

    public void update()
    {
        Random r = new Random();
        int nextValue = r.Next(0, 4);

        switch (nextValue)
        {
            case 0:
                sprite.update(this.xPos += 2, this.yPos);
                break;
            case 1:
                sprite.update(this.xPos -= 2, this.yPos);
                break;
            case 2:
                sprite.update(this.xPos, this.yPos += 2);
                break;
            case 3:
                sprite.update(this.xPos, this.yPos -= 2);
                break;

        }

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
            if (this.frame == 2)
            {
                this.frame = 0;
            }
        }
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(this.frame, sb);
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