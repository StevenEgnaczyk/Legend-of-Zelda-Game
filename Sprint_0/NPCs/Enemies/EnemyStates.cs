using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

public class EnemyState
{
    private IEnemy enemy;

    //0 = not facing left or right, 1 = left, 2 = right
    public int left { get; set; }

    //0 = not facing up or down, 1 = up, 2 = down
    public int up { get; set; }

    //health range TBD
    private int health;
    private string weapon;

    public EnemyState()
    {
        this.left = 1;
        this.up = 0;

        //initalize health
    }

    public void moveLeft()
    {
        this.left = 1;
        this.up = 0;
        //change the enemies xpos
    }

    public void moveRight()
    {
        this.left = 2;
        this.up = 0;
        //change the enemies xpos
    }

    public void moveUp()
    {
        this.up = 1;
        this.left = 0;
        //change the enemies ypos
    }
    public void moveDown()
    {
        this.up = 2;
        this.left = 0;
        //change the enemies ypos
    }

    public void hurt()
    {
        this.health--;
    }

    public void die()
    {
        //do nothhing for now
    }
}