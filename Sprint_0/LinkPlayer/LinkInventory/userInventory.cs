using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_0.LinkPlayer;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0.Interfaces;
using Sprint_0.HUD;

public class InventoryManager
{
    private Link Link;
    public userWeapons weaponManager;
    
    private int numBombs;
    private int numRupees;
    private int numKeys;

    public  List<IItem> itemList { get; set; }

    public InventoryManager(Link link)
    {
        this.Link = link;

        numBombs = 0;
        numKeys = 0;
        numRupees = 0;

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

    public void Draw(SpriteBatch spriteBatch)
    {
        DrawInventory(spriteBatch);
        DrawMap(spriteBatch);

    }

    private void DrawMap(SpriteBatch spriteBatch)
    {
    }

    private void DrawInventory(SpriteBatch spriteBatch)
    {
        DrawBaseInventory(spriteBatch);
    }

    private void DrawBaseInventory(SpriteBatch spriteBatch)
    {
        Texture2D baseInventory = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle baseInventorySourceRect = InventoryRectStorage.GetBaseInventorySourceRect();
        Rectangle baseInventoryDestRect = InventoryRectStorage.GetBaseInventoryDestRect();
        spriteBatch.Draw(baseInventory, baseInventoryDestRect, baseInventorySourceRect, Color.White);

    }

    public int getBombs()
    {
        return numBombs;
    }

    public int getRupees()
    {
        return numRupees;
    }

    public int getKeys()
    {
        return numKeys;
    }

    public IWeapon getPrimaryWeapon()
    {
        return weaponManager.getPrimaryWeapon();
    }

    public IWeapon getSecondaryWeapon()
    {
        return weaponManager.getSecondaryWeapon();
    }


}