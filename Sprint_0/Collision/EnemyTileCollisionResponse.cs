using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemyTileCollisionResponse
{
    public static void collisionResponse(IEnemy enemy, Tile tile)
    {
        /*
         * Uses sprite rectangles as hitboxes. Might want to add a method to
         * grab rectangles from enemy, Link, tile, items, weapons classes. Also 
         * should add get/set enemySpeed property (like linkSpeed) to enemy classes. 
         * Also, add heights and widths properties for weapons that get updated for
         * making rectangles
         */
        Rectangle enemyRec = new Rectangle( (int) enemy.xPos, (int) enemy.yPos, 16, 16);
        Rectangle tileRec = new Rectangle( (int) tile.xPos, (int) tile.yPos, 16, 16);


        /* 
         * Stops enemies and tiles occupying the same space, then makes sure the enemy 
         * turns away and doesn't collide again (not the same for collisions with link)
         */
        string collisionFace = CollisionDetection.collides(enemyRec, tileRec);
        switch (collisionFace)
        {
            case "Top":
               
                //Stopping the enemy from colliding with the tile
                enemy.yPos += 3;
               
                //Makes the enemy not run into the tile again
                enemy.moveDown();

                break;

            case "Left":

                enemy.xPos += 3;
                
                enemy.moveRight();

                break;

            case "Right":

                enemy.xPos -= 3;
                
                enemy.moveRight();

                break;

            case "Bottom":

                enemy.yPos -= 3;
               
                enemy.moveUp();

                break;
        }
    }
}