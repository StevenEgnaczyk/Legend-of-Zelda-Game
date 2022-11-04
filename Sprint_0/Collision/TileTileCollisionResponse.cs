using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class TileTileCollisionResponse
{

    public static void collisionResponse(ITile tile1, ITile tile)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle tile1Rec = new Rectangle(tile1.getXPos(), tile1.getYPos(), 64, 64);
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), 64, 64);


        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */
        if (!tile.Walkable())
        {
            string collisionFace = CollisionDetection.collides(tile1Rec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    //link.yPos += link.linkSpeed;

                    break;

                case "Left":

                    //link.xPos += link.linkSpeed;

                    break;

                case "Right":

                   // link.xPos -= link.linkSpeed;

                    break;

                case "Bottom":

                    //link.yPos -= link.linkSpeed;

                    break;
            }
        }
        // if (tile.Pushable())
        // {
        //     string collisionFace = CollisionDetection.collides(linkRec, tileRec);
        //     switch (collisionFace)
        //     {
        //         case "Top":

        //             link.yPos += link.linkSpeed;
        //             int y = tile.getYPos() - 1;
        //             tile.setYPos(y);
        //             break;

        //         case "Left":

        //             link.xPos += link.linkSpeed;
        //             int x = tile.getXPos() - 1;
        //             tile.setXPos(x);
        //             break;

        //         case "Right":

        //             link.xPos -= link.linkSpeed;
        //             int z = tile.getXPos() + 1;
        //             tile.setXPos(z);
        //             break;

        //         case "Bottom":

        //             link.yPos -= link.linkSpeed;
        //             int w = tile.getYPos() + 1;
        //             tile.setYPos(w);
        //             break;
        //     }
        // }
    }
}