using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Keese : IEnemy
{
    public EnemyState state {  get;  set; }
    private IEnemySprite sprite;
    private Enemy currentEnemy;

    public int xPos { get; set; }
    public int yPos { get; set; }
    private int bufferIndex;
    private int bufferMax = 20;
    private int frame;
    private SpriteBatch _spriteBatch;

    private EnemyManager man;

    public Keese(SpriteBatch sb, EnemyManager manager, int xPos, int yPos)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateKeeseSprite();
        this._spriteBatch = sb;

        this.xPos = xPos;
        this.yPos = yPos;
        this.frame = 0;
        this.bufferIndex = 0;

        man = manager;
        man.addEnemy(this);
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
        Random r = new Random();
        int nextValue = r.Next(0, 2);

        if (nextValue == 1)
        {
            sprite.update(this.xPos += 1, this.yPos);
        }
        else
        {
            sprite.update(this.xPos -= 1, this.yPos);
        }

        nextValue = r.Next(0, 2);

        if (nextValue == 1)
        {
            sprite.update(this.xPos, this.yPos += 1);
        }
        else
        {
            sprite.update(this.xPos, this.yPos -= 1);
        }

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

    public void draw()
    {
        throw new NotImplementedException();
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