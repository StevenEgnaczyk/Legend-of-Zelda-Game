using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Gel : IEnemy
{
    public EnemyState state {  get;  set; }
    private IEnemySprite sprite;

    public int xPos { get; set; }
    public int yPos { get; set; }
    private int bufferIndex;
    private int bufferMax = 20;

    private int frame;
    private SpriteBatch _spriteBatch;
    private Enemy currentEnemy;

    private EnemyManager man;

    public Gel(SpriteBatch sb, Enemy enemy, EnemyManager manager)
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateGelSprite();
        _spriteBatch = sb;
        currentEnemy = enemy;

        xPos = 300;
        yPos = 400;
        frame = 0;
        bufferIndex = 0;

        man = manager;
        man.addEnemy(this);

    }

    public void Next()
    {
        currentEnemy.currentEnemy = new Goriya(_spriteBatch, currentEnemy, man);
    }

    public void Prev()
    {
        currentEnemy.currentEnemy = new BladeTrap(_spriteBatch, currentEnemy, man);
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
        sprite.update(this.xPos, this.yPos);
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

    public int getEnemyUp()
    {
        return state.up;
    }

    public int getEnemyLeft()
    {
        return state.left;
    }
}