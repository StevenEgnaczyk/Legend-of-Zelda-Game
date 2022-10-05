using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class BladeTrap : IEnemy
{
    private EnemyState state;
    private IEnemySprite sprite;

    private int xPos;
    private int yPos;

    private SpriteBatch _spriteBatch;
    private Enemy currentEnemy;

    public BladeTrap(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateBladeTrapSprite();
        this._spriteBatch = sb;
        currentEnemy = enemy;

        this.xPos = 0;
        this.yPos = 0;
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

    /*
     * Blade traps cannot die, hence
     * the lack of a die() and hurt() 
     * method
     */

    public void update()
    {
        sprite.update(this.xPos, this.yPos);
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(0, sb);
    }
}