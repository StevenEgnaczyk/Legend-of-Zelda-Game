using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


public class ItemManager
{
    public List<IItem> itemList { get; set; }
    private static SpriteBatch sb;

    /* We only want one instance*/
    public static ItemManager instance = new ItemManager(sb);
    private static int HUD_SIZE = 224;

    public static ItemManager Instance
    {
        get
        {
            return instance;
        }
    }


    public ItemManager(SpriteBatch spriteBatch)
    {
        itemList = new List<IItem>();
        sb = spriteBatch;
    }

    public void addItem(IItem item)
    {
        itemList.Add(item);
    }

    public void removeItem(IItem item)
    {
        itemList.Remove(item);
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        foreach (IItem item in itemList)
        {
            item.Draw(spriteBatch);
        }

    }
}