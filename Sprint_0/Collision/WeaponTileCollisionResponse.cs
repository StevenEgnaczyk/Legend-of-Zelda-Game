using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0;



public class WeaponTileCollisionResponse
{
    public static void collisionResponse(userItems weapon, ITile tile)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        //IWeapon weaponObj = weapon.currentWeapon;
        Rectangle weaponRec = new Rectangle(weapon.currentWeapon.getXPos(), weapon.currentWeapon.getYPos(), weapon.currentWeapon.getWidth(), weapon.currentWeapon.getHeight());
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), 16, 16);


        /* 
         * Weapons continue after colliding with an enemy (not the case for a collidable tile
         */
        string collisionFace = CollisionDetection.collides(weaponRec, tileRec);
        if (collisionFace != "No Collision")
        {
            //TO DO: Make weapon do contact animation
        }
    }
}