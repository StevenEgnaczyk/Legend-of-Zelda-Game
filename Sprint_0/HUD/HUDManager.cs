using Microsoft.Xna.Framework;
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
        private Inventory linkInventory;
        private int compassIndex;

        public HUDManager(Link player, Inventory inventory)
        {
            this.link = player;
            this.linkInventory = inventory;

        }

        //draws all HUD aspects with default placement
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBasicHUD(spriteBatch, 0, 0);
            DrawLevelText(spriteBatch, 0, 0);
            DrawLinkLocation(spriteBatch, 0, 0);
            DrawItems(spriteBatch, 0, 0);
            DrawWeapons(spriteBatch, 0, 0);
            DrawLife(spriteBatch, 0, 0);

        }
        
        //draws all HUD aspects with defined offset
        public void Draw(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            DrawBasicHUD(spriteBatch, xOffset, yOffset);
            DrawLevelText(spriteBatch, xOffset, yOffset);
            DrawLinkLocation(spriteBatch, xOffset, yOffset);
            DrawItems(spriteBatch, xOffset, yOffset);
            DrawWeapons(spriteBatch, xOffset, yOffset);
            DrawLife(spriteBatch, xOffset, yOffset);
            
        }

        //Draws text for HUD with defined offset
        private void DrawLevelText(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle levelTextSourceRect = HUDRectStorage.GetLevelTextSourceRect();
            Rectangle levelTextDestRect = HUDRectStorage.GetLevelTextDestRect();
            levelTextDestRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, levelTextDestRect, levelTextSourceRect, Color.White);

            Rectangle levelNumSourceRect = HUDRectStorage.getDigit(1);
            Rectangle levelNumDestRect = HUDRectStorage.GetLevelNumDestRect();
            levelNumDestRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, levelNumDestRect, levelNumSourceRect, Color.White);


        }

        //Draws health bar
        private void DrawLife(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();

            int heartIndex = 0;
            float linkHealth = link.getHealth();
            float maxHealth = link.getMaxHealth();

            while (linkHealth > 0.5)
            {
                
                Rectangle heartSourceRect = HUDRectStorage.GetFullHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                heartDestRect.Offset(xOffset, yOffset);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
                linkHealth -= 1.0f;
                heartIndex++;
            }

            if (linkHealth % 1.0 == 0.5)
            {
                Rectangle heartSourceRect = HUDRectStorage.GetHalfHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                heartDestRect.Offset(xOffset, yOffset);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
                heartIndex++;
            }

            while (heartIndex < maxHealth)
            {
                Rectangle heartSourceRect = HUDRectStorage.GetEmptyHeartSourceRect();
                Rectangle heartDestRect = HUDRectStorage.GetHeartDestRect(heartIndex);
                heartDestRect.Offset(xOffset, yOffset);
                spriteBatch.Draw(basicHUD, heartDestRect, heartSourceRect, Color.White);
                heartIndex++;
            }
        }

        //Draws weapon selection for link HUD
        private void DrawWeapons(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            DrawPrimaryWeapon(spriteBatch, xOffset, yOffset);
            DrawSecondaryWeapon(spriteBatch, xOffset, yOffset);
        }

        private void DrawSecondaryWeapon(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle secondaryWeaponSourceRect = HUDRectStorage.GetSecondaryWeaponSourceRect(linkInventory.secondaryWeaponManager.secondaryWeapon);
            Rectangle secondaryWeaponDestRect = HUDRectStorage.GetSecondaryWeaponDestRect();
            secondaryWeaponDestRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, secondaryWeaponDestRect, secondaryWeaponSourceRect, Color.White);
        }

        private void DrawPrimaryWeapon(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle primaryWeaponSourceRect = HUDRectStorage.GetPrimaryWeaponSourceRect(linkInventory.primaryWeaponManager.primaryWeapon);
            Rectangle primaryWeaponDestRect = HUDRectStorage.GetPrimaryWeaponDestRect();
            primaryWeaponDestRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, primaryWeaponDestRect, primaryWeaponSourceRect, Color.White);
            
        }

        //draws item inventory for HUD
        private void DrawItems(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            DrawDaTokens(spriteBatch, xOffset, yOffset);
            DrawRupees(spriteBatch, xOffset, yOffset);
            DrawKeys(spriteBatch, xOffset, yOffset);
            DrawBombs(spriteBatch, xOffset, yOffset);
            
        }

        //draw DaBaby tokens for inventory
        private void DrawDaTokens(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            int numDaTokens = link.inventory.getDaTokens();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getDaTokensXDestRect();
            xDestRect.Offset(xOffset, yOffset);

            if (numDaTokens > 10)
            {
                digit1SourceRect = HUDRectStorage.getDigit(numDaTokens / 10);
                digit2SourceRect = HUDRectStorage.getDigit(numDaTokens % 10);
            }
            else
            {
                digit1SourceRect = HUDRectStorage.getDigit(numDaTokens);
                digit2SourceRect = HUDRectStorage.getBlank();
            }

            Rectangle digit1DestRect = HUDRectStorage.getDaTokensDigit1DestRect();
            digit1DestRect.Offset(xOffset, yOffset);
            Rectangle digit2DestRect = HUDRectStorage.getDaTokensDigit2DestRect();
            digit2DestRect.Offset(xOffset, yOffset);

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }

        //draws bomb storage for HUD
        private void DrawBombs(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            int numBombs = link.inventory.getBombs();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getBombXDestRect();
            xDestRect.Offset(xOffset, yOffset);

            if (numBombs >= 10)
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
            digit1DestRect.Offset(xOffset, yOffset);
            Rectangle digit2DestRect = HUDRectStorage.getBombDigit2DestRect();
            digit2DestRect.Offset(xOffset, yOffset);

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }

        //Draws key number in inventory for HUD
        private void DrawKeys(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            int numKeys = link.inventory.getKeys();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getKeyXDestRect();
            xDestRect.Offset(xOffset, yOffset);

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
            digit1DestRect.Offset(xOffset, yOffset);
            Rectangle digit2DestRect = HUDRectStorage.getKeyDigit2DestRect();
            digit2DestRect.Offset(xOffset, yOffset);

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }

        //draws number of rupees for HUD
        private void DrawRupees(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            int numRupees = link.inventory.getRupees();
            Rectangle digit1SourceRect;
            Rectangle digit2SourceRect;

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle xSourceRect = HUDRectStorage.getXIcon();
            Rectangle xDestRect = HUDRectStorage.getRupeeXDestRect();
            xDestRect.Offset(xOffset, yOffset);

            if (numRupees >= 10)
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
            digit1DestRect.Offset(xOffset, yOffset);
            Rectangle digit2DestRect = HUDRectStorage.getRupeeDigit2DestRect();
            digit2DestRect.Offset(xOffset, yOffset);

            spriteBatch.Draw(basicHUD, xDestRect, xSourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit1DestRect, digit1SourceRect, Color.White);
            spriteBatch.Draw(basicHUD, digit2DestRect, digit2SourceRect, Color.White);
        }
    
        //draws map for HUD
        private void DrawLinkLocation(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {

            if (link.inventory.HasMap())
            {
                DrawMap(spriteBatch, xOffset, yOffset);
            }

            if (link.inventory.HasCompass())
            {
                DrawCompassLocation(spriteBatch, xOffset, yOffset);
            }

            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle sourceRect = HUDRectStorage.getMapIcon(link.currentRoom);
            Rectangle destinationRect = HUDRectStorage.getMapLocation(link.currentRoom);
            destinationRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, destinationRect, sourceRect, Color.White);

        }

        private void DrawCompassLocation(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle sourceRect = HUDRectStorage.getBlinkingLocation(compassIndex);
            Rectangle destinationRect = HUDRectStorage.getBossCompassLocation();
            destinationRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, destinationRect, sourceRect, Color.White);
            compassIndex++;
            if (compassIndex > 100)
            {
                compassIndex = 0;
            }
        }

        private void DrawMap(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D HUDSpritesheet = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle mapRoomRectSource = InventoryRectStorage.GetHUDMapRoomRectSource();

            for (int i = 0; i < RoomManager.NUM_ROOMS - 1; i++)
            {
               
                Rectangle mapRoomRectDest = InventoryRectStorage.GetHUDMapRoomRectDest(0, i);
                mapRoomRectDest.Offset(xOffset, yOffset);
                spriteBatch.Draw(HUDSpritesheet, mapRoomRectDest, mapRoomRectSource, Color.White);

            }
        }

        //draws basic HUD elements
        public void DrawBasicHUD(SpriteBatch spriteBatch, int xOffset, int yOffset)
        {
            Texture2D basicHUD = Texture2DStorage.GetHUDSpriteSheet();
            Rectangle sourceRect = HUDRectStorage.getBasicHUD();
            Rectangle destinationRect = new Rectangle(0, 0, sourceRect.Width * 4, sourceRect.Height * 4);
            destinationRect.Offset(xOffset, yOffset);
            spriteBatch.Draw(basicHUD, destinationRect, sourceRect, Color.White);
        }
    }
}
