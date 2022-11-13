using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public  class EnemyManager
{
    public  List<IEnemy> enemiesList { get; set; }
    private static SpriteBatch sb;
    

    /* We only want one instance*/
    public  static EnemyManager instance = new EnemyManager(sb);

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

        for (int i = 0; i < enemiesList.Count; i++)
        {
            IEnemy enemy = enemiesList[i];
            enemy.update();
            enemy.draw(sb);
        }        
        
    }

}