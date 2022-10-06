using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleEnemyNextCommand : ICommand
{
    public IEnemy enemy;

    public CycleEnemyNextCommand(IEnemy e)
    {
        enemy = e;
    }

    public void Execute()
    {
        enemy.Next();
        for(int i = 0; i < 10; i++)
        {
            enemy.moveLeft();
            enemy.update();

        }
    }
}