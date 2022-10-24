using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;

public class EnemyWeaponCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, userItems weapon)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        int fillerNumThatNeedsToBeReplaced = 0;
        Rectangle enemyRec = new Rectangle((int)enemy.xPos, (int)enemy.yPos, 16, 16);
        Rectangle weaponRec = new Rectangle(fillerNumThatNeedsToBeReplaced, fillerNumThatNeedsToBeReplaced, 16, 16); //need weapon position, width and height methods


        /* 
         * Hurts enemy, then kicks back if weapon collides with direction enemy 
         * is facing
         */
        string collisionFace = CollisionDetection.collides(enemyRec, weaponRec);
        int up = enemy.getEnemyUp();
        int left = enemy.getEnemyLeft();
        switch (collisionFace)
        {
            case "Top":

                enemy.hurt();
                if (up == 1)
                {
                    //big pushback for enemy needed
                }

                //make weapon disappear?

                break;

            case "Left":

                enemy.hurt();
                if (left == 1)
                {
                }


                break;

            case "Right":

                enemy.hurt();
                if (left == 2)
                {
                }

                break;

            case "Bottom":

                enemy.hurt();
                if (up == 2)
                {
                }

                break;
        }
    }
}