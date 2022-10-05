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

    private int xPos;
    private int yPos;

    private SpriteBatch _spriteBatch;
    private int frame;

    public Wallmaster(SpriteBatch sb)
    {
        //that state initailization smells funny
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateWallmasterSprite();
        this._spriteBatch = sb;

        this.xPos = 0;
        this.yPos = 0;
        this.frame = 1;
    }

    public void Next()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateGoriyaSprite();
    }

    public void Prev()
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        sprite = EnemySpriteAndStateFactory.instance.CreateBladeTrapSprite();
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
}