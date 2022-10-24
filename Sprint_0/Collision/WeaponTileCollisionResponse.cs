using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Player;
using Sprint_0.Interfaces;


public class WeaponTileCollisionResponse
{
    public static void collisionResponse(userItems weapon, ITile tile)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        IWeapon weaponObj = weapon.currentWeapon;
        Rectangle weaponRec = new Rectangle(weaponObj.getXPos(), weaponObj.getYPos(), weaponObj.getWidth(), weaponObj.getHeight());
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