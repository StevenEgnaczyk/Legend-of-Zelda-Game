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
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        //IPrimaryWeapon weaponObj = weapon.currentWeapon;
        Rectangle weaponRec = userInv.getWeapon();
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());


        /* 
         * Weapons continue after colliding with an enemy (not the case for a collidable tile
         */
        if (!tile.Walkable())
        {
            string collisionFace = CollisionDetection.collides(weaponRec, tileRec);
            if (collisionFace != "No Collision")
            {
                userInv.StopUsingWeapon();
            }
        }
    }
}