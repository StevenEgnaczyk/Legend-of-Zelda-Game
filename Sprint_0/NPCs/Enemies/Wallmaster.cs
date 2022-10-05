using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Wallmaster : IEnemy
{
    private EnemyState state;
    private IEnemySprite sprite;
    private Enemy currentEnemy;

    private int xPos;
    private int yPos;
    private int bufferIndex;
    private int bufferMax = 20;

    private SpriteBatch _spriteBatch;
    private int frame;

    public Wallmaster(SpriteBatch sb, Enemy enemy)
    {
        //that state initailization smells funny
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateWallmasterSprite();
        this._spriteBatch = sb;
        currentEnemy = enemy;

        this.xPos = 300;
        this.yPos = 400;
        this.frame = 0;
        this.bufferIndex = 0;
    }

    public void Next()
    {
        currentEnemy.currentEnemy = new Aquamentus(_spriteBatch, currentEnemy);
    }

    public void Prev()
    {
        currentEnemy.currentEnemy = new Stalfos(_spriteBatch, currentEnemy);
    }

    public void moveLeft()
    {
        state.moveLeft();
    }

    public void moveRight()
    {
        state.moveRight();
    }

    public void moveUp()
    {
        state.moveUp();
    }

    public void moveDown()
    {
        state.moveDown();
    }

    public void hurt()
    {
        //nothing to do here yet
    }

    public void die()
    {
        //nothing to do here yet
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
}