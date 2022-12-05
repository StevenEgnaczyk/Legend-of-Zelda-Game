using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemyTileCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, ITile tile)
    {
        /*
         * Use sprite destination rectangles as hitboxes. 
         */
        Rectangle enemyRec = new Rectangle((int) enemy.xPos, (int) enemy.yPos, enemy.getWidth(), enemy.getHeight());
        Rectangle tileRec = new Rectangle((int)tile.getXPos(), (int)tile.getYPos(), tile.getWidth(), tile.getHeight());


        /* 
         * Stops enemies and tiles occupying the same space, then makes sure the enemy 
         * turns away and doesn't collide again (not the same for collisions with link)
         */
        if (!tile.Walkable())
        {
            string collisionFace = CollisionDetection.collides(enemyRec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    //Stopping the enemy from colliding with the tile and change its direction
                    enemy.yPos += enemy.getSpeed();
                    enemy.moveDown();
                    break;

                case "Left":

                    //Stopping the enemy from colliding with the tile and change its direction
                    enemy.xPos -= enemy.getSpeed();
                    enemy.moveRight();
                    break;

                case "Right":

                    //Stopping the enemy from colliding with the tile and change its direction
                    enemy.xPos += enemy.getSpeed();
                    enemy.moveLeft();
                    break;

                case "Bottom":

                    //Stopping the enemy from colliding with the tile and change its direction
                    enemy.yPos -= enemy.getSpeed();
                    enemy.moveUp();
                    break;
            }
        }
    }
}