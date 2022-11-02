using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;

public class InventoryManager
{
    private Link Link;
    public primaryWeaponManager primaryWeaponManager;
    public secondaryWeaponManager secondaryWeaponManager;

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
        primaryWeaponManager = new primaryWeaponManager(link);
        secondaryWeaponManager = new secondaryWeaponManager(link);

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
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        for (int i = 0; i < RoomManager.NUM_ROOMS; i++)
        {
            Rectangle mapRoomRectSource = InventoryRectStorage.GetMapRoomRectSource(0, i);
            Rectangle mapRoomRectDest = InventoryRectStorage.GetMapRoomRectDest(0, i);
            mapRoomRectDest.Offset(xOffset, yOffset); 
            spriteBatch.Draw(HUDSpritesheet, mapRoomRectDest, mapRoomRectSource, Color.White);

        }

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
        DrawInventoryItems(spriteBatch, xOffset, yOffset);
        DrawMapSection(spriteBatch, xOffset, yOffset);
    }

    private void DrawInventoryItems(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();

        foreach (secondaryWeaponManager.secondaryWeapons secondaryWeapon in secondaryWeaponManager.secondaryWeaponList)
        {
            Rectangle secondaryWeaponSource = InventoryRectStorage.GetSecondaryWeaponSourceRect(secondaryWeapon);
            Rectangle secondaryWeaponDest = InventoryRectStorage.GetSecondaryWeaponDestRect(secondaryWeapon);
            secondaryWeaponDest.Offset(xOffset, yOffset);
            spriteBatch.Draw(HUDSpritesheet, secondaryWeaponDest, secondaryWeaponSource, Color.White);
        }
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
        return primaryWeaponManager.getPrimaryWeapon();
    }

    public IWeapon getSecondaryWeapon()
    {
        return secondaryWeaponManager.getSecondaryWeapon();
    }

    internal void Draw(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        DrawInventory(spriteBatch, xOffset, yOffset);
    }
}