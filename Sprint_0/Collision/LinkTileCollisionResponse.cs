using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkTileCollisionResponse
{
    public static void collisionResponse(Link link, Tile tile)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int)link.xPos, (int)link.yPos, 16, 16);
        Rectangle tileRec = new Rectangle((int)tile.xPos, (int)tile.yPos, 16, 16);


        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */
        string collisionFace = CollisionDetection.collides(linkRec, tileRec);
        switch (collisionFace)
        {
            case "Top":

                link.yPos -= link.linkSpeed;

                break;

            case "Left":

                link.xPos += link.linkSpeed;

                break;

            case "Right":

                link.xPos -= link.linkSpeed;

                break;

            case "Bottom":

                link.yPos -= link.linkSpeed;

                break;
        }
    }
}