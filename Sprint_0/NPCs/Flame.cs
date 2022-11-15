using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Reflection.Metadata;
public class Flame : IEnemy
{
    //public OldManSprite sprite;
    public IEnemyState state { get; set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const int enemySpeed = 3;
    private SpriteBatch _spriteBatch;
    private EnemyManager man;

    /* Buffer properties*/
    private int[] bufferVals = new int[3];

    public Flame(EnemyManager manager, int startX, int startY)
    {
        state = new IdleEnemyState(this);
        xPos = startX;
        yPos = startY;
        health = 1;

        sprite = EnemySpriteFactory.instance.CreateFlameSprite();
        man = manager;
        randTime = 1000;

        //Enemy adds itself to the list of enemies
        man.addEnemy(this);
    }
    
    public void Update()
    {
        throw new NotImplementedException();
    }
    public void Draw(SpriteBatch _spriteBatch)
    {

        bufferVals[2] = 20;
    }

    public void moveLeft() { }

    public void moveRight() { }

    public void moveUp() { }

    public void moveDown() { }

    public void hurt() { }

    public void idle() { }

    public void update()
    {
        if (Buffer.itemBuffer(bufferVals))
        {
            state.update();
            sprite.update(xPos, yPos, 0, 0);

        }

    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(sb);
    }

    public void changeToRandState() { }

    /*
     * Getter methods
     */
    public int getHeight()
    {
        return height;
    }

    public int getWidth()
    {
        return width;
    }

    public int getSpeed()
    {
        return enemySpeed;
    }
}
