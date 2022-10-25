using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.HUD
{
    public class HUDManager
    {

        private Link link;
        private userInventory linkInventory;

        public HUDManager(Link player, userInventory inventory)
        {
            this.link = player;
            this.linkInventory = inventory;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawBasicHUD(spriteBatch);
            DrawMap(spriteBatch);
            DrawItems(spriteBatch);
            DrawWeapons(spriteBatch);
            DrawLife(spriteBatch);
        }

        private void DrawLife(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        private void DrawWeapons(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        private void DrawItems(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
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
