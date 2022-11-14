using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0;



public class WeaponDoorCollisionResponse
{
    public static void collisionResponse(Inventory userInv, IDoor door)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        //IPrimaryWeapon weaponObj = weapon.currentWeapon;
        Rectangle weaponRec = userInv.getWeapon();
        Rectangle doorRect = new Rectangle(door.getXPos(), door.getYPos(), door.getWidth(), door.getHeight());


        /* 
         * Weapons continue after colliding with an enemy (not the case for a collidable tile
         */
            string collisionFace = CollisionDetection.collides(weaponRec, doorRect);
            if (collisionFace != "No Collision")
            {
                userInv.StopUsingWeapon();
            }
        
    }
}