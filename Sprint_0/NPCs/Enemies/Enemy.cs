﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Enemy : IEnemy
    {

    public IEnemy currentEnemy;

    public Enemy(SpriteBatch sb)
    {
        currentEnemy = new Keese(sb, this);
    }
    public void draw(SpriteBatch _spriteBatch)
    {
        currentEnemy.update();
        currentEnemy.draw(_spriteBatch);
    }

    public void moveLeft()
    {
        throw new NotImplementedException();
    }

    public void moveRight()
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
        currentEnemy.update();
    }
}

