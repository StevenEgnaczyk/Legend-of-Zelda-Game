using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class CycleEnemyPrevCommand : ICommand
{
    public IEnemy enemy;

    public CycleEnemyPrevCommand(IEnemy e)
    {
        enemy = e;
    }

    public void Execute()
    {
        enemy.Prev();
        enemy.update();
    }
}