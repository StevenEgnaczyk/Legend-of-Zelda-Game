using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_0.LinkPlayer;


public class ItemManager
{
    public  List<IItem> itemList { get; set; }

    /* We only want one instance*/
    public static ItemManager instance = new ItemManager();

    public static ItemManager Instance
    {
        get
        {
            return instance;
        }
    }

    public ItemManager()
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