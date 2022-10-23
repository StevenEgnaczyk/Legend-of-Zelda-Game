using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


public class ItemManager
{
    public  List<Item> itemList { get; set; }

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
        itemList = new List<Item>();
    }

    public void addItem(Item item)
    {
        itemList.Add(item);
    }

    public void removeItem(Item item)
    {
        itemList.Remove(item);
    }

    public void Update()
    {
        foreach (Item item in itemList)
        {
            item.Update();
        }
    }

    public void Draw()
    {
        foreach (Item item in itemList)
        {
            item.Draw(item._spriteBatch);
        }
    }

}