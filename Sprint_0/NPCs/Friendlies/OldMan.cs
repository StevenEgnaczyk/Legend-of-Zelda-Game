using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
public class OldMan : IEnemy
{

    //public OldManSprite sprite;
    public IEnemyState state { get; set; }
    public float xPos { get; set; }
    public float yPos { get; set; }
    public int health { get; set; }
    public int randTime { get; set; }

    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const float enemySpeed = 3;
    private SpriteBatch _spriteBatch;
    private EnemyManager man;

    public OldMan(EnemyManager manager, int startX, int startY)
    {
        state = new IdleEnemyState(this);
        xPos = startX +32;
        yPos = startY;

        sprite = EnemySpriteFactory.instance.CreateOldManSprite();
        man = manager;
        man.addEnemy(this);
    }

    public void moveLeft() { }

    public void moveRight() { }

    public void moveUp() { }

    public void moveDown() { }

    public void hurt() { }

    public void die() { }

    public void idle() { }

    public void update() {

            state.update();
            sprite.update(xPos, yPos, state.facingDirection, randTime);

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

    public float getSpeed()
    {
        return enemySpeed;
    }

    public void shootProjectile()
    {
        throw new NotImplementedException();
    }

    public bool damaged()
    {
        return false;
    }
}
