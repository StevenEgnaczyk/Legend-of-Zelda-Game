using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public class Keese : IEnemy
{
    private EnemyState state;
    private IEnemySprite sprite;

    private int xPos;
    private int yPos;

    private int frame;
    private SpriteBatch _spriteBatch;

    public Keese(SpriteBatch sb)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateKeeseSprite();
        this._spriteBatch = sb;

        this.xPos = 0;
        this.yPos = 0;
        this.frame = 0;
    }

    public void Next()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateStalfosSprite();
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
        sprite.update(xPos, yPos);
    }

    public void draw()
    {
        sprite.draw(frame, _spriteBatch); 
    }
}