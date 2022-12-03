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

    public void removeEnemy(IEnemy enemy)
    {
        
        enemiesList.Remove(enemy);

        if (enemiesList.Count == 0)
        {
            ItemManager.instance.dropKey(enemy.xPos, enemy.yPos);
            PuzzleManager.instance.managePuzzles();
        }
        else
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 100);

            if (num >= 0 && num < 30)
            {
                ItemManager.instance.dropRupee(enemy.xPos, enemy.yPos);
            }
            else if (num >= 30 && num < 50)
            {
                ItemManager.instance.dropHeart(enemy.xPos, enemy.yPos);
            }

        }


    }
    //seperate remove Enemy methods to prevent extra items from dropping
    public void removeEnemy(GoriyaBoomerang gb)
    {
        enemiesList.Remove(gb);
    }

    public void removeEnemy(AquamentusFireball af) {
        enemiesList.Remove(af);
    }
    public void removeEnemy(AdamSandlerGolfBall gb)
    {
        enemiesList.Remove(gb);
    }
    public void removeEnemy(DeathAnimation da)
    {
        enemiesList.Remove(da);
        if (enemiesList.Count == 0)
        {
            ItemManager.instance.dropKey(da.xPos, da.yPos);
            PuzzleManager.instance.managePuzzles();
        }
    }

    public void removeEnemy(AdamSandler sandler)
    {
        enemiesList.Remove(sandler);
        ItemManager.instance.dropDaCoin(sandler.xPos, sandler.yPos);
    }

    public void Update()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            IEnemy enemy = enemiesList[i];
            enemy.update();
        }
    }

    public void Draw()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            IEnemy enemy = enemiesList[i];
            enemy.update();
            enemy.draw(sb);
        }
    }

    public void getEnemyByIndex(EnemyManager enemyManager, int enemyIndex, int row, int col)
    {
        switch (enemyIndex)
        {
            case 21:
                new Keese(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 22:
                new Stalfos(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 23:
                new Goriya(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 24:
                new Wallmaster(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 25:
                new Aquamentus(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 26:
                new BladeTrap(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 27:
                new Gel(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 28:
                new OldMan(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 29:
                new Flame(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 40:
                new AdamSandler(enemyManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
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

            e.state.moveLeft(e);

        } else if (randVal == 1)
        {

            e.state.moveDown(e);

        } else if (randVal == 2)
        {

            e.state.moveLeft(e);

        } else if (randVal == 3)
        {

            e.state.moveRight(e);

        }else if (randVal == 4)
        {

            e.shootProjectile();
        }else if(randVal == 5)
        {

            e.shootProjectile();
        }else if(randVal == 6)
        {

            e.shootProjectile();
        }
    }

}