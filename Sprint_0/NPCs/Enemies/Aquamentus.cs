using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Aquamentus : IEnemy
{
    private Enemy currentEnemy;
    private EnemyState state;
    private IEnemySprite sprite;


    private int xPos;
    private int yPos;
    private int bufferIndex;
    private int bufferMax = 20;
    private int frame;
    private SpriteBatch _spriteBatch;

    public Aquamentus(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateAquamentusSprite();
        currentEnemy = enemy;
        this._spriteBatch = sb;
        this.bufferIndex = 0;
        this.frame = 0;
        this.xPos = 300;
        this.yPos = 400;
    }
    public void Next()
    {
        currentEnemy.currentEnemy = new BladeTrap(_spriteBatch, currentEnemy);
    }
    public void Prev()
    {
        currentEnemy.currentEnemy = new Wallmaster(_spriteBatch, currentEnemy);
    }

    public void moveLeft()
    {
        state.moveLeft();
    }

    public void moveRight()
    {
        state.moveRight();
    }

    /* 
     * Aquamentus cannot move vertically,
     * hence  moveUp() and moveDown() are
     * not existant.
     */

    public void shootProjectile()
    {
        //nothing yet
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
            if (this.frame == 4)
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