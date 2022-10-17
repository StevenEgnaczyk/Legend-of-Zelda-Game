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


    public int xPos { get; set; }
    public int yPos { get; set; }
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
        state.moveLeft(this);
    }

    public void moveRight()
    {
        state.moveRight(this);
    }

    public void moveUp()
    {
        //do nothing, it cannot  move up 
    }

    public void moveDown()
    {
        //do nothing, it cannot move down
    }

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
                Random r = new Random();
                int nextValue = r.Next(0, 2);

                if (nextValue == 1)
                {
                    sprite.update(this.xPos += 3, this.yPos);
                }
                else
                {
                    sprite.update(this.xPos -= 3, this.yPos);
                }
                this.frame = 0;
            }
        }
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(this.frame, sb);
    }
}