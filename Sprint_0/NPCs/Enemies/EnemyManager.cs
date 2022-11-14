using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;

public  class EnemyManager
{
    public  List<IEnemy> enemiesList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public  static EnemyManager instance = new EnemyManager(sb);
    private static int HUD_SIZE = 224;

    public  static EnemyManager Instance
    {
        get
        {
            return instance;
        }
    }

    
    public EnemyManager(SpriteBatch spritebatch)
    {
        enemiesList = new List<IEnemy>();
        sb = spritebatch;
    }

    public void addEnemy(IEnemy enemy)
    {
        enemiesList.Add(enemy);
    }

    public void removeEnemy (IEnemy enemy)
    {
        enemiesList.Remove(enemy);
    }

    public void Update()
    {
        foreach (IEnemy enemy in enemiesList)
        {
            enemy.update();
        }
    }

    public void Draw()
    {
        foreach (IEnemy enemy in enemiesList)
        {
            enemy.update();
            enemy.draw(sb);
        }
    }

    public void getEnemyByIndex(EnemyManager enemyManager, int enemyIndex, int row, int col)
    {
        switch (enemyIndex)
        {
            case 21:
                new Keese(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 22:
                new Stalfos(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 23:
                new Goriya(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 24:
                new Wallmaster(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 25:
                new Aquamentus(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 26:
                new BladeTrap(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 27:
                new Gel(this, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            default:
                break;

        }
    }

    public void randomStateGenerator(IEnemy e, int bound1, int bound2)
    {
        Random r = new Random();
        int randVal = r.Next(bound1, bound2);

        if(randVal == 0)
        {

            e.state = new UpMovingEnemyState(e);

        } else if (randVal == 1)
        {

            e.state = new DownMovingEnemyState(e);

        } else if (randVal == 2)
        {

            e.state = new LeftMovingEnemyState(e);

        } else if (randVal == 3)
        {

            e.state = new RightMovingEnemyState(e);

        } else if (randVal == 4)
        {

            e.state = new ShootingProjectileEnemyState(e, e.state.facingDirection);

        }
    }

}