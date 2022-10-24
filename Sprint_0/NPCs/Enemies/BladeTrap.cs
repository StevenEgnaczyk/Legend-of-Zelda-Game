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

    private EnemyManager man;

    public BladeTrap(SpriteBatch sb, EnemyManager manager, int startX, int startY)
    {
        this.state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        this.sprite = EnemySpriteAndStateFactory.instance.CreateBladeTrapSprite();
        this._spriteBatch = sb;

        this.xPos = startX;
        this.yPos = startY;

        man = manager;
        man.addEnemy(currentEnemy);

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
