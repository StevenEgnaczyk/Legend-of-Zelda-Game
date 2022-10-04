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
        enemy.update();
    }
}