﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.HUD
{
    public class HUDManager
    {

        private Link link;
        private InventoryManager linkInventory;

        public HUDManager(Link player, InventoryManager inventory)
        {
            this.link = player;
            this.linkInventory = inventory;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBasicHUD(spriteBatch);
            DrawLevelText(spriteBatch);
            DrawMap(spriteBatch);
            DrawItems(spriteBatch);
            DrawWeapons(spriteBatch);
            DrawLife(spriteBatch);
            
        }

        private void DrawLevelText(SpriteBatch spriteBatch)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle levelTextSourceRect = HUDRectStorage.GetLevelTextSourceRect();
            Rectangle levelTextDestRect = HUDRectStorage.GetLevelTextDestRect();
            spriteBatch.Draw(basicHUD, levelTextDestRect, levelTextSourceRect, Color.White);

            Rectangle levelNumSourceRect = HUDRectStorage.getDigit(1);
            Rectangle levelNumDestRect = HUDRectStorage.GetLevelNumDestRect();
            spriteBatch.Draw(basicHUD, levelNumDestRect, levelNumSourceRect, Color.White);


        }

        private void DrawLife(SpriteBatch spriteBatch)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();

            int heartIndex = 0;
            float linkHealth = link.getHealth();
            float maxHealth = link.getMaxHealth();

            while (linkHealth > 0.5)
            {
                
                Rectangle heartSourceRect = HUDRectStorage.GetFullHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
                linkHealth -= 1.0f;
                heartIndex++;
            }

            if (linkHealth > 0)
            {
                Rectangle heartSourceRect = HUDRectStorage.GetHalfHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
            }

            while (heartIndex < maxHealth)
            {
                Rectangle heartSourceRect = HUDRectStorage.GetEmptyHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
            }
        }

        private void DrawWeapons(SpriteBatch spriteBatch)
        {
            DrawPrimaryWeapon(spriteBatch);
            //DrawSecondaryWeapon(spriteBatch);
        }

        private void DrawSecondaryWeapon(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        private void DrawPrimaryWeapon(SpriteBatch spriteBatch)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle primaryWeaponSourceRect = HUDRectStorage.GetPrimaryWeaponSourceRect(linkInventory.weaponManager.primaryWeapon);
            Rectangle primaryWeaponDestRect = HUDRectStorage.GetPrimaryWeaponDestRect();
            spriteBatch.Draw(basicHUD, primaryWeaponDestRect, primaryWeaponSourceRect, Color.White);
            
        }

        private void DrawItems(SpriteBatch spriteBatch)
        {
            DrawRupees(spriteBatch);
            DrawKeys(spriteBatch);
            DrawBombs(spriteBatch);
            
        }

        private void DrawBombs(SpriteBatch spriteBatch)
        {
            int numBombs = link.inventory.getBombs();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getBombXDestRect();

            if (numBombs > 10)
            {
                digit1SourceRect = HUDRectStorage.getDigit(numBombs / 10);
                digit2SourceRect = HUDRectStorage.getDigit(numBombs % 10);
            }
            else
            {
                digit1SourceRect = HUDRectStorage.getDigit(numBombs);
                digit2SourceRect = HUDRectStorage.getBlank();
            }

            Rectangle digit1DestRect = HUDRectStorage.getBombDigit1DestRect();
            Rectangle digit2DestRect = HUDRectStorage.getBombDigit2DestRect();

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }

        private void DrawKeys(SpriteBatch spriteBatch)
        {
            int numKeys = link.inventory.getKeys();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getKeyXDestRect();

            if (numKeys > 10)
            {
                digit1SourceRect = HUDRectStorage.getDigit(numKeys / 10);
                digit2SourceRect = HUDRectStorage.getDigit(numKeys % 10);
            }
            else
            {
                digit1SourceRect = HUDRectStorage.getDigit(numKeys);
                digit2SourceRect = HUDRectStorage.getBlank();
            }

            Rectangle digit1DestRect = HUDRectStorage.getKeyDigit1DestRect();
            Rectangle digit2DestRect = HUDRectStorage.getKeyDigit2DestRect();

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }

        private void DrawRupees(SpriteBatch spriteBatch)
        {
            int numRupees = link.inventory.getRupees();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getRupeeXDestRect();

            if (numRupees > 10)
            {
                digit1SourceRect = HUDRectStorage.getDigit(numRupees / 10);
                digit2SourceRect = HUDRectStorage.getDigit(numRupees % 10);
            }
            else
            {
                digit1SourceRect = HUDRectStorage.getDigit(numRupees);
                digit2SourceRect = HUDRectStorage.getBlank();
            }

            Rectangle digit1DestRect = HUDRectStorage.getRupeeDigit1DestRect();
            Rectangle digit2DestRect = HUDRectStorage.getRupeeDigit2DestRect();

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }
    

        private void DrawMap(SpriteBatch spriteBatch)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle sourceRect = HUDRectStorage.getMapIcon();
            Rectangle destinationRect = HUDRectStorage.getMapLocation(link.currentRoom);
            spriteBatch.Draw(basicHUD, destinationRect, sourceRect, Color.White);
        }

        public void DrawBasicHUD(SpriteBatch spriteBatch)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle sourceRect = HUDRectStorage.getBasicHUD();
            Rectangle destinationRect = new Rectangle(0, 0, sourceRect.Width * 4, sourceRect.Height * 4);
            spriteBatch.Draw(basicHUD, destinationRect, sourceRect, Color.White);
        }
    }
}
