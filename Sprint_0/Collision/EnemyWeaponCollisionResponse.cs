using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemyWeaponCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, userItems weapon)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle enemyRec = new Rectangle((int)enemy.xPos, (int)enemy.yPos, 16, 16);
        Rectangle weaponRec = new Rectangle((int)weapon.xPos, (int)weapon.yPos, 16, 16); //currently set to 16x16,but will need to change


        /* 
         * Hurts enemy, then kicks back if weapon collides with direction enemy 
         * is facing
         */
        string collisionFace = CollisionDetection.collides(enemyRec, weaponRec);
        switch (collisionFace)
        {
            case "Top":

                enemy.hurt();
                if (enemy.state.up == 1)
                {
                    //big pushback for enemy needed
                }

                //make weapon disappear?

                break;

            case "Left":

                enemy.hurt();
                if (enemy.state.left == 1)
                {
                }


                break;

            case "Right":

                enemy.hurt();
                if (enemy.state.up == 2)
                {
                }

                break;

            case "Bottom":

                enemy.hurt();
                if (enemy.state.up == 2)
                {
                }

                break;
        }
    }
}