using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class BladeTrap : IEnemy
{
    public EnemyState state {  get;  set; }
    private IEnemySprite sprite;

    public int xPos { get; set; }
    public int yPos { get; set; }

    private SpriteBatch _spriteBatch;
    private Enemy currentEnemy;

    public BladeTrap(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateBladeTrapSprite();
        this._spriteBatch = sb;
        currentEnemy = enemy;

        this.xPos = 300;
        this.yPos = 400;
    }

    public void Next()
    {
        currentEnemy.currentEnemy = new Gel(_spriteBatch, currentEnemy);
    }

    public void Prev()
    {
        currentEnemy.currentEnemy = new Aquamentus(_spriteBatch, currentEnemy);
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
        //do nothing, cannot die
    }

    public void update()
    {
        sprite.update(this.xPos, this.yPos);
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(0, sb);
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
