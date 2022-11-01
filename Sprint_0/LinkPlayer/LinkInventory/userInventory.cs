using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;

public class InventoryManager
{
    private Link Link;
    public userWeapons weaponManager;

    private int numBombs;
    private int numRupees;
    private int numKeys;

    private bool hasMap;
    private bool hasCompass;

    public List<IItem> itemList { get; set; }

    public InventoryManager(Link link)
    {
        this.Link = link;

        numBombs = 0;
        numKeys = 0;
        numRupees = 0;
        hasMap = true;
        hasCompass = true;

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
        DrawInventory(spriteBatch, 0, 0);
    }

    private void DrawMapSection(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D baseMapSection = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle baseMapSourceRect = InventoryRectStorage.GetBaseMapSourceRect();
        Rectangle baseMapDestRect = InventoryRectStorage.GetBaseMapDestRect();
        baseMapDestRect.Offset(xOffset, yOffset);
        spriteBatch.Draw(baseMapSection, baseMapDestRect, baseMapSourceRect, Color.White);

        if (hasMap)
        {
            DrawMapIcon(spriteBatch, xOffset, yOffset);
            DrawMap(spriteBatch, xOffset, yOffset);
        }
        else
        {
            DrawEmptyMapIcon(spriteBatch, xOffset, yOffset);
        }

        if (hasCompass)
        {
            DrawCompassIcon(spriteBatch, xOffset, yOffset);
        }
        else
        {
            DrawEmptyCompassIcon(spriteBatch, xOffset, yOffset);
        }

    }

    private void DrawEmptyCompassIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle emptyCompassSource = InventoryRectStorage.GetEmptyCompassSourceRect();
        Rectangle emptyCompassDest = InventoryRectStorage.GetEmptyCompassDestRect();
        emptyCompassDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, emptyCompassDest, emptyCompassSource, Color.White);
    }

    private void DrawCompassIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle compassSource = InventoryRectStorage.GetCompassSourceRect();
        Rectangle compassDest = InventoryRectStorage.GetCompassDestRect();
        compassDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, compassDest, compassSource, Color.White);
    }

    private void DrawEmptyMapIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle emptyMapSource = InventoryRectStorage.GetEmptyMapSourceRect();
        Rectangle emptyMapDest = InventoryRectStorage.GetEmptyMapDestRect();
        emptyMapDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, emptyMapSource, emptyMapDest, Color.White);
    }

    private void DrawMap(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {

    }

    private void DrawMapIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle mapSource = InventoryRectStorage.GetMapSourceRect();
        Rectangle mapDest = InventoryRectStorage.GetMapDestRect();
        mapDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, mapDest, mapSource, Color.White);
    }

    private void DrawInventory(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        DrawBaseInventory(spriteBatch, xOffset, yOffset);
        DrawMapSection(spriteBatch, xOffset, yOffset);
    }

    private void DrawBaseInventory(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D baseInventory = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle baseInventorySourceRect = InventoryRectStorage.GetBaseInventorySourceRect();
        Rectangle baseInventoryDestRect = InventoryRectStorage.GetBaseInventoryDestRect();
        baseInventoryDestRect.Offset(xOffset, yOffset);
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

    internal void Draw(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        DrawInventory(spriteBatch, xOffset, yOffset);
    }
}