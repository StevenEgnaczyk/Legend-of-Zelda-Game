using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemManager
{
    public List<IItem> itemList { get; set; }
    private static SpriteBatch sb;
    private static Room room;

    /* We only want one instance*/
    public static ItemManager instance = new ItemManager(room, sb);
    private static int HUD_SIZE = 224;

    public static ItemManager Instance
    {
        get
        {
            return instance;
        }
    }


    public ItemManager(Room currentRoom, SpriteBatch spriteBatch)
    {
        itemList = new List<IItem>();
        room = currentRoom;
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

    public void getItemByIndex(ItemManager itemManager, int itemIndex, int row, int col)
    {
        switch (itemIndex)
        {
            case 31:
                new Candle(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 32:
                new WoodenBoomerang(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 33:
                new Bow(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 34:
                new Bomb(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 35:
                new Compass(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 36:
                new Map(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 37:
                new Key(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
            case 38:
                new DaCoin(itemManager, 64 + (col * 64), HUD_SIZE + 64 + (64 * row));
                break;
                
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        foreach (IItem item in itemList)
        {
            item.Draw(spriteBatch);
        }

    }

    internal void dropKey(int xPos, int yPos)
    {
        new Key(room.getItemManager(), xPos, yPos);
    }

    internal void dropHeart(int xPos, int yPos)
    {
        new Heart(room.getItemManager(), xPos, yPos);
    }

    internal void dropRupee(int xPos, int yPos)
    {
        new Rupee(room.getItemManager(), xPos, yPos);
    }
}