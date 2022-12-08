using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;

public class Inventory
{
    //inventory properties
    private Link Link;
    public primaryWeaponManager primaryWeaponManager;
    public secondaryWeaponManager secondaryWeaponManager;
    public InventoryManager inventoryManager;

    private int numDaTokens;
    private int numBombs;
    private int numRupees;
    private int numKeys;

    private bool hasMap;
    private bool hasCompass;
    private bool hasAlbum;

    public Inventory(Link link)
    {
        this.Link = link;

        numDaTokens = 0;
        numBombs = 0;
        numKeys = 0;
        numRupees = 0;

        hasMap = false;
        hasCompass = false;
        hasAlbum = false;

        primaryWeaponManager = new primaryWeaponManager(link);
        secondaryWeaponManager = new secondaryWeaponManager(link);
        inventoryManager = new InventoryManager(link, this);
    }

    //adds item to inventory
    public void addItem(IItem item)
    {
        AudioStorage.GetGetItem().Play();
        switch (item)
        {
            case Candle:
                AudioStorage.GetGetItem().Play();
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Fire);
                break;
            case Bow:
                AudioStorage.GetGetItem().Play();
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Bow);
                break;
            case Arrow:

                break;
            case Bomb:
                AudioStorage.GetGetItem().Play();
                this.addBombs();
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Bomb);
                break;
            case Clock:
                break;
            case Compass:
                AudioStorage.GetGetItem().Play();
                this.hasCompass = true;
                break;
            case Fairy:
                break;
            case Heart:
                AudioStorage.GetGetItem().Play();
                this.Link.gainHealth();
                break;
            case HeartContainer:

                break;
            case Key:
                AudioStorage.GetGetItem().Play();
                this.addKeys();
                break;
            case Map:
                AudioStorage.GetGetItem().Play();
                this.hasMap = true;
                break;
            case Rupee:
                AudioStorage.GetGetItem().Play();
                this.addRupee();
                break;
            case WoodenBoomerang:
                AudioStorage.GetGetItem().Play();
                this.secondaryWeaponManager.AddSecondaryWeapon(secondaryWeaponManager.secondaryWeapons.Boomerang);
                break;
            case DaCoin:
                AudioStorage.GetLetsGo2().Play();
                this.addDaTokens();
                if (this.numDaTokens >= 5)
                {
                    PuzzleManager.instance.managePuzzles();
                }
                break;

            case Album:
                hasAlbum = true;
                break;

        }
    }

    //adds to count for DaBaby tokens
    private void addDaTokens()
    {
        numDaTokens++;
    }

    //adds to count for keys
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

    //adds to conut for bombs
    public void addBombs()
    {
        numBombs++;
    }

    //adds to count for rupees
    public void addRupee()
    {
        numRupees++;
    }

    //removes bomb, and deals with secondary weapon manager
    public void removeBombs()
    {
        numBombs--;
        if (numBombs == 0)
        {
            secondaryWeaponManager.secondaryWeaponList.Remove(secondaryWeaponManager.secondaryWeapons.Bomb);
            if (secondaryWeaponManager.secondaryWeaponList.Count == 0)
            {
                secondaryWeaponManager.secondaryWeapon = secondaryWeaponManager.secondaryWeapons.None;
            }
            else if (secondaryWeaponManager.secondaryWeaponList.Contains(secondaryWeaponManager.secondaryWeapons.Bow))
            {
                secondaryWeaponManager.secondaryWeapon = secondaryWeaponManager.getSecondaryWeaponTypeByInt(2);
            }
            else if (secondaryWeaponManager.secondaryWeaponList.Contains(secondaryWeaponManager.secondaryWeapons.Boomerang))
            {
                secondaryWeaponManager.secondaryWeapon = secondaryWeaponManager.getSecondaryWeaponTypeByInt(0);
            }
            else if (secondaryWeaponManager.secondaryWeaponList.Contains(secondaryWeaponManager.secondaryWeapons.Fire))
            {
                secondaryWeaponManager.secondaryWeapon = secondaryWeaponManager.getSecondaryWeaponTypeByInt(3);
            }
        }
    }

    //get methods
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

    public bool HasAlbum()
    {
        return hasAlbum;
    }

    public void removeAlbum()
    {
        hasAlbum = false;
    }

    public bool HasCompass()
    {
        return hasCompass;
    }

    public Rectangle getWeapon()
    {
        if (primaryWeaponManager.usingPrimaryWeapon)
        {
            return primaryWeaponManager.getRect();
        }
        else if (secondaryWeaponManager.usingSecondaryWeapon)
        {
            return secondaryWeaponManager.getRect();
        }
        else
        {
            return new Rectangle(0, 0, 0, 0);
        }
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

    internal bool UsingWeapon()
    {
        return primaryWeaponManager.usingPrimaryWeapon || secondaryWeaponManager.usingSecondaryWeapon;
    }

    internal void StopUsingWeapon()
    {
        if (primaryWeaponManager.usingPrimaryWeapon)
        {
            primaryWeaponManager.stopUsingWeapon();
        }
        else if (secondaryWeaponManager.usingSecondaryWeapon)
        {
            secondaryWeaponManager.stopUsingWeapon();
        }
    }

    internal void removeKey()
    {
        numKeys--;
    }

    internal int getDaTokens()
    {
        return numDaTokens;
    }
}