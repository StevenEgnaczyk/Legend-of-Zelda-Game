using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

namespace Sprint_0.Collision
{
    public class EnemyDoorCollisionResponse
    {
        public static void collisionResponse(IEnemy enemy, IDoor door)
        {
            /*
             * Use sprite destination rectangles as hitboxes. 
             */
            Rectangle enemyRec = new(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());
            Rectangle doorRect = new(door.getXPos(), door.getYPos(), 128, 128);


            /* 
             * Stops enemies and tiles occupying the same space, then makes sure the enemy 
             * turns away and doesn't collide again (not the same for collisions with link)
             */
                string collisionFace = CollisionDetection.collides(enemyRec, doorRect);
                switch (collisionFace)
                {
                    case "Top":

                        //Stopping the enemy from colliding with the tile
                        enemy.yPos += enemy.getSpeed();

                        //Makes the enemy not run into the tile again
                        enemy.moveDown();

                        break;

                    case "Left":

                        enemy.xPos -= enemy.getSpeed();
                        enemy.moveRight();

                        break;

                    case "Right":

                        enemy.xPos += enemy.getSpeed();
                        enemy.moveLeft();

                        break;

                    case "Bottom":

                        enemy.yPos -= enemy.getSpeed();
                        enemy.moveUp();

                        break;
                
            }
        }
    }
}