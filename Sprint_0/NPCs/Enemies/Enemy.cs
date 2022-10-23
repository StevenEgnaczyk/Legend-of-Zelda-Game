using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Enemy : IEnemy
    {

    public IEnemy currentEnemy;
    public EnemyState state {  get;  set; }


    public int xPos { get; set; }
    public int yPos { get; set; }   

    private EnemyManager man;

    public Enemy(SpriteBatch sb, EnemyManager manager)
    {
        currentEnemy = new Keese(sb, this, man);
        man = manager;
        man.addEnemy(currentEnemy);


    }
    public void draw(SpriteBatch _spriteBatch)
    {
        currentEnemy.update();
        currentEnemy.draw(_spriteBatch);
    }

    public void moveLeft()
    {
        currentEnemy.moveLeft();
    }

    public void moveRight()
    {
        throw new NotImplementedException();
    }

    public void moveUp()
    {
        throw new NotImplementedException();
    }

    public void moveDown()
    {
        throw new NotImplementedException();
    }
    public void hurt()
    {
        throw new NotImplementedException();
    }

    public void Next(SpriteBatch sb)
    {
        currentEnemy.Next();
    }

    public void Next()
    {
        currentEnemy.Next();
    }

    public void Prev()
    {
        currentEnemy.Prev();
    }

    public void update()
    {
        currentEnemy.moveLeft();
        currentEnemy.update();
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

