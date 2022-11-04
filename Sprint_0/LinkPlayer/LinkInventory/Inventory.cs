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

    public Inventory(Link link)
    {
        this.Link = link;

        numBombs = 0;
        numKeys = 0;
        numRupees = 0;
        hasMap = false;
        hasCompass = false;
        primaryWeaponManager = new primaryWeaponManager(link);
        secondaryWeaponManager = new secondaryWeaponManager(link);
        inventoryManager = new InventoryManager(link, this);
    }

    public void addItem(IItem item)
    {
        switch(item)
        {
            case Candle:
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Fire);
                break;
            case Bow:
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Bow);
                break;
            case Arrow:

                break;
            case Bomb:
                this.addBombs();
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Bomb);
                break;
            case Clock:
                break;
            case Compass:
                this.hasCompass = true;
                break;
            case Fairy:
                break;
            case Heart:

                break;
            case HeartContainer:

                break;
            case Key:
                this.addKeys();
                break;
            case Map:
                this.hasMap = true;
                break;
            case Rupee:

                break;
            case WoodenBoomerang:
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Boomerang);
                break;

        }
    }

    private void addKeys()
    {
        numKeys++;
    }

    public void DrawInventory(SpriteBatch spriteBatch)
    {
        inventoryManager.DrawInventory(spriteBatch, 0, 0);
    }

    public int getBombs()
    {
        return numBombs;
    }

    public void addBombs()
    {
        numBombs++;
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

    public IPrimaryWeapon getPrimaryWeapon()
    {
        return primaryWeaponManager.getPrimaryWeapon();
    }

    public ISecondaryWeapon getSecondaryWeapon()
    {
        return secondaryWeaponManager.getSecondaryWeapon();
    }

    internal void Draw(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        inventoryManager.DrawInventory(spriteBatch, xOffset, yOffset);
    }

    public void Update()
    {
        primaryWeaponManager.Update();
        secondaryWeaponManager.Update();
    }
}