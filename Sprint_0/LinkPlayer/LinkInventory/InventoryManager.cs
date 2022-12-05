using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Diagnostics;

public class InventoryManager
{
    private Link link;
    private Inventory inventory;
    private int selectedWeaponIndex;

    public InventoryManager(Link link, Inventory inventory)
    {
        this.link = link;
        this.inventory = inventory;
    }

    /* Draw the inventory screen */
    public void DrawInventory(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        DrawBaseInventory(spriteBatch, xOffset, yOffset);
        DrawInventoryItems(spriteBatch, xOffset, yOffset);
        DrawMapSection(spriteBatch, xOffset, yOffset);

    }

    /* Draws the base inventory screen with all the weapons and items */
    private void DrawBaseInventory(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D baseInventory = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle baseInventorySourceRect = InventoryRectStorage.GetBaseInventorySourceRect();
        Rectangle baseInventoryDestRect = InventoryRectStorage.GetBaseInventoryDestRect();
        baseInventoryDestRect.Offset(xOffset, yOffset);
        spriteBatch.Draw(baseInventory, baseInventoryDestRect, baseInventorySourceRect, Color.White);

        /* If link has a weapon, draw it */
        if (link.inventory.secondaryWeaponManager.hasSecondaryWeapon)
        {
            DrawCurrentWeapon(spriteBatch, xOffset, yOffset);
        }

    }

    /* Draws the current weapon in the base inventory */
    private void DrawCurrentWeapon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D baseMapSection = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle secondaryWeaponSource = InventoryRectStorage.GetSecondaryWeaponSourceRect(inventory.secondaryWeaponManager.secondaryWeapon);
        Rectangle secondaryWeaponDest = InventoryRectStorage.GetCurrentSecondaryWeaponDestinationRect();
        secondaryWeaponDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(baseMapSection, secondaryWeaponDest, secondaryWeaponSource, Color.White);
    }

    //draws map if map item has been collected, same with compass
    private void DrawMapSection(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D baseMapSection = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle baseMapSourceRect = InventoryRectStorage.GetBaseMapSourceRect();
        Rectangle baseMapDestRect = InventoryRectStorage.GetBaseMapDestRect();
        baseMapDestRect.Offset(xOffset, yOffset);
        spriteBatch.Draw(baseMapSection, baseMapDestRect, baseMapSourceRect, Color.White);

        if (inventory.HasMap())
        {
            DrawMapIcon(spriteBatch, xOffset, yOffset);
            DrawMap(spriteBatch, xOffset, yOffset);
        }
        else
        {
            DrawEmptyMapIcon(spriteBatch, xOffset, yOffset);
        }

        if (inventory.HasCompass())
        {
            DrawCompassIcon(spriteBatch, xOffset, yOffset);
        }
        else
        {
            DrawEmptyCompassIcon(spriteBatch, xOffset, yOffset);
        }

    }

    //draw for when the compass has not been collected
    private void DrawEmptyCompassIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle emptyCompassSource = InventoryRectStorage.GetEmptyCompassSourceRect();
        Rectangle emptyCompassDest = InventoryRectStorage.GetEmptyCompassDestRect();
        emptyCompassDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, emptyCompassDest, emptyCompassSource, Color.White);
    }

    //draw for when compass has been collected
    private void DrawCompassIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle compassSource = InventoryRectStorage.GetCompassSourceRect();
        Rectangle compassDest = InventoryRectStorage.GetCompassDestRect();
        compassDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, compassDest, compassSource, Color.White);
    }

    //draw for when map has not been collected
    private void DrawEmptyMapIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle emptyMapSource = InventoryRectStorage.GetEmptyMapSourceRect();
        Rectangle emptyMapDest = InventoryRectStorage.GetEmptyMapDestRect();
        emptyMapDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, emptyMapSource, emptyMapDest, Color.White);
    }

    //draw for when map has been collected
    private void DrawMap(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        for (int i = 0; i < RoomManager.NUM_ROOMS - 1; i++)
        {
            Rectangle mapRoomRectSource = InventoryRectStorage.GetMapRoomRectSource(0, i);
            Rectangle mapRoomRectDest = InventoryRectStorage.GetMapRoomRectDest(0, i);
            mapRoomRectDest.Offset(xOffset, yOffset);
            spriteBatch.Draw(HUDSpritesheet, mapRoomRectDest, mapRoomRectSource, Color.White);

        }

    }

    //draws icon for map
    private void DrawMapIcon(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
        Rectangle mapSource = InventoryRectStorage.GetMapSourceRect();
        Rectangle mapDest = InventoryRectStorage.GetMapDestRect();
        mapDest.Offset(xOffset, yOffset);
        spriteBatch.Draw(HUDSpritesheet, mapDest, mapSource, Color.White);
    }

    //draw for general inventory
    private void DrawInventoryItems(SpriteBatch spriteBatch, int xOffset, int yOffset)
    {
        Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();

        foreach (secondaryWeaponManager.secondaryWeapons secondaryWeapon in inventory.secondaryWeaponManager.secondaryWeaponList)
        {
            Rectangle secondaryWeaponSource = InventoryRectStorage.GetSecondaryWeaponSourceRect(secondaryWeapon);
            Rectangle secondaryWeaponDest = InventoryRectStorage.GetSecondaryWeaponDestRect(secondaryWeapon);
            secondaryWeaponDest.Offset(xOffset, yOffset);
            spriteBatch.Draw(HUDSpritesheet, secondaryWeaponDest, secondaryWeaponSource, Color.White);
        }

        if (inventory.secondaryWeaponManager.hasSecondaryWeapon)
        {
            Texture2D baseInventory = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle weaponBoxSource = InventoryRectStorage.GetWeaponBoxSource();
            Rectangle secondaryWeaponDest = InventoryRectStorage.GetSecondaryWeaponDestRect(inventory.secondaryWeaponManager.secondaryWeapon);
            secondaryWeaponDest.Offset(xOffset, yOffset);
            spriteBatch.Draw(baseInventory, secondaryWeaponDest, weaponBoxSource, Color.White);
        }
    }
    
    //get and set methods to find secondary weapon's index
    public int getSelectedSecondaryWeaponIndex()
    {
        return selectedWeaponIndex;
    }
    public void setSelectedSecondaryWeaponIndex(secondaryWeaponManager.secondaryWeapons weapon)
    {
        switch (weapon)
        {
            case secondaryWeaponManager.secondaryWeapons.Boomerang: 
                selectedWeaponIndex = 0;
                break;
            case secondaryWeaponManager.secondaryWeapons.Bomb:
                selectedWeaponIndex = 1;
                break;
            case secondaryWeaponManager.secondaryWeapons.Bow:
                selectedWeaponIndex = 2;
                break;
            case secondaryWeaponManager.secondaryWeapons.Fire:
                selectedWeaponIndex = 3;
                break;
        }
    }

    //cycle for secondary weapon switching
    internal void cycleItemRight()
    {
        int startingIndex = selectedWeaponIndex;
        selectedWeaponIndex++;
        if (selectedWeaponIndex == 4)
        {
            selectedWeaponIndex = 0;
        }
        while ((selectedWeaponIndex != startingIndex) && !(inventory.secondaryWeaponManager.HasSelectedWeapon(selectedWeaponIndex))) {
            selectedWeaponIndex++;

            if (selectedWeaponIndex == 4)
            {
                selectedWeaponIndex = 0;
            }
        }
        inventory.secondaryWeaponManager.setSecondaryWeaponTypeByInt(selectedWeaponIndex);
    }

    internal void cycleItemLeft()
    {
        int startingIndex = selectedWeaponIndex;
        selectedWeaponIndex--;
        if (selectedWeaponIndex == -1)
        {
            selectedWeaponIndex = 3;
        }
        while ((selectedWeaponIndex != startingIndex) && !(inventory.secondaryWeaponManager.HasSelectedWeapon(selectedWeaponIndex)))
        {
            selectedWeaponIndex--;

            if (selectedWeaponIndex == -1)
            {
                selectedWeaponIndex = 3;
            }
        }
        inventory.secondaryWeaponManager.setSecondaryWeaponTypeByInt(selectedWeaponIndex);
    }
}
