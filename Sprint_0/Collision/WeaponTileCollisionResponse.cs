using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0;



public class WeaponTileCollisionResponse
{
    public static void collisionResponse(Inventory userInv, ITile tile)
    {

        Rectangle weaponRec = userInv.getWeapon();
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());


        //Stop using the weapon if it collides with a non-walkable tile (except for water)
        if (!tile.Walkable())
        {
            if (!tile.GetType().ToString().Equals("WaterTile"))
            {
                string collisionFace = CollisionDetection.collides(weaponRec, tileRec);
                if (collisionFace != "No Collision")
                {
                    userInv.StopUsingWeapon();
                }
            }
        }
    }
}