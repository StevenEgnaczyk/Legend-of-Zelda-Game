using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
public class OldMan : IEnemy
{

    //public OldManSprite sprite;
    public EnemyState state { get; set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int health { get; set; }
    /* Properties that reference or get referenced frequently*/
    private IEnemySprite sprite;
    private const int height = 64;
    private const int width = 64;
    private const int enemySpeed = 3;
    private SpriteBatch _spriteBatch;
    private EnemyManager man;

    public OldMan(SpriteBatch sb, EnemyManager manager, int startX, int startY)
    {
        state = EnemySpriteAndStateFactory.instance.CreateEnemyState();
        xPos = startX +32;
        yPos = startY;

        sprite = EnemySpriteAndStateFactory.instance.CreateOldManSprite();
        _spriteBatch = sb;
        man = manager;
    }
    /*public void Update()
    {
        throw new NotImplementedException();
    }
    public void Draw(SpriteBatch _spriteBatch)
    {

    }
    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D oldManSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)x, (int)y, sourceRect.Width * 3, sourceRect.Height * 3);
        _spriteBatch.Draw(oldManSprite, destinationRect, sourceRect, Color.White);
    }*/

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
        sprite.update(xPos, yPos);
    }

    public void draw(SpriteBatch sb)
    {
        sprite.draw(0, sb);
    }

    /*
     * Getter methods
     */
    public int getEnemyUp()
    {
        return state.up;
    }

    public int getEnemyLeft()
    {
        return state.left;
    }

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
