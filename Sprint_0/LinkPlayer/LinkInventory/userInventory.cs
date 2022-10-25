using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_0.LinkPlayer;
using Sprint_0.LinkPlayer.LinkInventory;

public class userInventory
{
    public userWeapons weapons;
    private int numBombs;
    private int numRupees;
    private int numKeys;

    public  List<IItem> itemList { get; set; }

    /* We only want one instance*/
    public static userInventory instance = new userInventory();

    public static userInventory Instance
    {
        get
        {
            return instance;
        }
    }

    public userInventory()
    {
        itemList = new List<IItem>();
    }

    public void addItem(IItem item)
    {
        itemList.Add(item);
    }

    public void removeItem(IItem item)
    {
        itemList.Remove(item);
    }

    public void Update()
    {
        foreach (IItem item in itemList)
        {
            item.Update();
        }
    }

    public void Draw()
    {
        foreach (IItem item in itemList)
        {
            //item.draw(); TO DO: change item draw to not need spritebatch
        }
    }

}