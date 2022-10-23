using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Goriya : IEnemy
{
    public EnemyState state {  get;  set; }
    private IEnemySprite sprite;
    private Enemy currentEnemy;

    public int xPos { get; set; }
    public int yPos { get; set; }
    private int bufferIndex;
    private int bufferMax = 20;

    private EnemyManager man;

    private int frame;
    private SpriteBatch _spriteBatch;

    public Goriya(SpriteBatch sb, Enemy enemy, EnemyManager manager)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateGoriyaSprite();
        currentEnemy = enemy;
        this._spriteBatch = sb;

        xPos = 300;
        yPos = 400;
        frame = 0;
        bufferIndex = 0;
        
        man = manager;
        man.addEnemy(this);

    }

    public void Next()
    {
        currentEnemy.currentEnemy = new Keese(_spriteBatch, currentEnemy, man);
    }

    public void Prev()
    {
        currentEnemy.currentEnemy = new Gel(_spriteBatch, currentEnemy, man);
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

    public void hurt()
    {
        //nothing to do here yet
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
    public int getEnemyUp()
    {
        return state.up;
    }

    public int getEnemyLeft()
    {
        return state.left;
    }
}