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

    private int frame;
    private SpriteBatch _spriteBatch;

    public Aquamentus(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateAquamentusSprite();
        currentEnemy = enemy;
        this._spriteBatch = sb;

        this.frame = 0;
        this.xPos = 0;
        this.yPos = 0;
    }
    public void Next()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateBladeTrapSprite();
        currentEnemy.currentEnemy = new BladeTrap(_spriteBatch, currentEnemy);
    }
    public void Prev()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateGoriyaSprite();
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
        int x = xPos;
        int y = yPos;
        sprite.update(x, y);
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(this.frame, sb);
    }
}