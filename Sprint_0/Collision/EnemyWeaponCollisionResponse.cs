using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Player;

public class EnemyWeaponCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, userItems weapon)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        int fillerNumThatNeedsToBeReplaced = 0;
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());
        Rectangle weaponRec = new Rectangle(fillerNumThatNeedsToBeReplaced, fillerNumThatNeedsToBeReplaced, 16, 16); //need weapon position, width and height methods


        /* 
         * Hurts enemy, then kicks back if weapon collides with direction enemy 
         * is facing
         */
        string collisionFace = CollisionDetection.collides(enemyRec, weaponRec);
        switch (collisionFace)
        {
            case "Top":

                enemy.hurt();
                if (enemy.getEnemyUp() == 1)
                {
                    //big pushback for enemy needed
                }

                //make weapon disappear?

                break;

            case "Left":

                enemy.hurt();
                if (enemy.getEnemyLeft() == 1)
                {
                }


                break;

            case "Right":

                enemy.hurt();
                if (enemy.getEnemyLeft() == 2)
                {
                }

                break;

            case "Bottom":

                enemy.hurt();
                if (enemy.getEnemyUp() == 2)
                {
                }

                break;
        }
    }
}