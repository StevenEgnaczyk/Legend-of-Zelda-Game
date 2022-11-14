using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemyDoorCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, IDoor door)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());
        Rectangle doorRect = new Rectangle((int)door.getXPos(), (int)door.getYPos(), door.getWidth(), door.getHeight());


        /* 
         * Stops enemies and tiles occupying the same space, then makes sure the enemy 
         * turns away and doesn't collide again (not the same for collisions with link)
         */
        if (door.Locked())
        {
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
                    enemy.moveLeft();

                    break;

                case "Right":

                    enemy.xPos += enemy.getSpeed();
                    enemy.moveRight();

                    break;

                case "Bottom":

                    enemy.yPos -= enemy.getSpeed();
                    enemy.moveUp();

                    break;
            }
        }
    }
}