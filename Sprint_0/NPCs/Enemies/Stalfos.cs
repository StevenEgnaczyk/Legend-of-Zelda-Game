using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Stalfos : IEnemy
{
    private EnemyState state;
    private IEnemySprite sprite;
    private Enemy currentEnemy;

    private int xPos;
    private int yPos;
    private int bufferIndex;
    private int bufferMax = 20;

    private int frame;
    private SpriteBatch _spriteBatch;

    public Stalfos(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateStalfosSprite();
        this._spriteBatch = sb; 
        this.currentEnemy = enemy;

        this.xPos = 300;
        this.yPos = 400;
        this.frame = 0;
        this.bufferIndex = 0;
    }

    public void Next()
    {
        currentEnemy.currentEnemy = new Wallmaster(_spriteBatch, currentEnemy);
    }

    public void Prev()
    {
        currentEnemy.currentEnemy = new Keese(_spriteBatch, currentEnemy);
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