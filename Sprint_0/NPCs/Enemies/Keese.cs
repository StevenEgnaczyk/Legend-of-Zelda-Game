using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Keese : IEnemy
{
    private EnemyState state;
    private IEnemySprite sprite;
    private Enemy currentEnemy;

    private int xPos;
    private int yPos;

    private int frame;
    private SpriteBatch _spriteBatch;

    public Keese(SpriteBatch sb, Enemy enemy)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateKeeseSprite();
        this._spriteBatch = sb;
        currentEnemy = enemy;

        this.xPos = 0;
        this.yPos = 0;
        this.frame = 0;
    }

    public void Next()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateStalfosSprite();
        currentEnemy.currentEnemy = new Stalfos(_spriteBatch, currentEnemy);

    }

    public void Prev()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateAquamentusSprite();
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
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(this.frame, sb); 
    }

    public void draw()
    {
        throw new NotImplementedException();
    }
}