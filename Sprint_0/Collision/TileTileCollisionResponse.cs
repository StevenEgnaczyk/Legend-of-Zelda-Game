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

                    tile1.setYPos(tile1.getYPos() + 3);

                    break;

                case "Left":

                    tile1.setXPos(tile1.getXPos() + 3);

                    break;

                case "Right":

                    tile1.setXPos(tile1.getXPos() - 3);

                    break;

                case "Bottom":

                    tile1.setYPos(tile1.getYPos() - 3);

                    break;
            }
        }
    }
}