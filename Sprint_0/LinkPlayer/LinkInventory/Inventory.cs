using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;

public class Inventory
{
    private Link Link;
    public primaryWeaponManager primaryWeaponManager;
    public secondaryWeaponManager secondaryWeaponManager;
    public InventoryManager inventoryManager;

    private int numBombs;
    private int numRupees;
    private int numKeys;

    private bool hasMap;
    private bool hasCompass;

    public List<IItem> itemList { get; set; }

    public Inventory(Link link)
    {
        this.Link = link;

        numBombs = 0;
        numKeys = 0;
        numRupees = 0;
        hasMap = true;
        hasCompass = true;
        primaryWeaponManager = new primaryWeaponManager(link);
        secondaryWeaponManager = new secondaryWeaponManager(link);
        inventoryManager = new InventoryManager(link, this);
        itemList = new List<IItem>();
    }

    public void addItem(IItem item)
    {
        switch(item)
        {
            case Candle:
                secondaryWeaponManager.secondaryWeaponList.Add(secondaryWeaponManager.secondaryWeapons.Fire);
                break;

        }
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
        inventoryManager.DrawInventory(spriteBatch, 0, 0);
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

    public bool HasMap()
    {
        return hasMap;
    }

    public bool HasCompass()
    {
        return hasCompass;
    }

    public IWeapon getPrimaryWeapon()
    {
        return primaryWeaponManager.getPrimaryWeapon();
    }

    public IWeapon getSecondaryWeapon()
    {
        return secondaryWeaponManager.getSecondaryWeapon();
    }

    internal void Draw(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        inventoryManager.DrawInventory(spriteBatch, xOffset, yOffset);
    }
}