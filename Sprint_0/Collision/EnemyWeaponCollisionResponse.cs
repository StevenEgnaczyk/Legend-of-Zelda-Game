using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0.LinkPlayer;
using Sprint_0.Interfaces;

public class EnemyWeaponCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, primaryWeaponManager userInv)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());
        Rectangle weaponRec = new Rectangle(userInv.primaryWeapon.getXPos(), userInv.primaryWeapon.getYPos(), userInv.primaryWeapon.getWidth(), userInv.primaryWeapon.getHeight());

        /* 
         * Weapons continue after colliding with an enemy (not the case for a collidable tile
         */
        string collisionFace = CollisionDetection.collides(enemyRec, weaponRec);
        if (collisionFace != "No Collision")
        {
            enemy.hurt();
        }
    }
}