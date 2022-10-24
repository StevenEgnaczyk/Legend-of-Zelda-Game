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
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), 16, 16);


        /* 
         * Stops enemies and tiles occupying the same space, then makes sure the enemy 
         * turns away and doesn't collide again (not the same for collisions with link)
         */
        string collisionFace = CollisionDetection.collides(enemyRec, tileRec);
        switch (collisionFace)
        {
            case "Top":
               
                //Stopping the enemy from colliding with the tile
                enemy.yPos += enemy.getSpeed();
               
                //Makes the enemy not run into the tile again
                enemy.moveDown();

                break;

            case "Left":

                enemy.xPos += enemy.getSpeed(); ;
                
                enemy.moveRight();

                break;

            case "Right":

                enemy.xPos -= enemy.getSpeed(); ;
                
                enemy.moveRight();

                break;

            case "Bottom":

                enemy.yPos -= enemy.getSpeed(); ;
               
                enemy.moveUp();

                break;
        }
    }
}