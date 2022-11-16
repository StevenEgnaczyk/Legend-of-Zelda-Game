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
        Rectangle tile1Rec = new Rectangle(tile1.getXPos(), tile1.getYPos(), tile1.getWidth(), tile1.getHeight());
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());


        /* Stop blocks from pushing against each other */
        if (!tile.Walkable())
        {
            string collisionFace = CollisionDetection.collides(tile1Rec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    tile1.setYPos(tile1.getYPos() + GlobalVariables.TILE_PUSHBACK_SPEED);

                    break;

                case "Left":

                    tile1.setXPos(tile1.getXPos() + GlobalVariables.TILE_PUSHBACK_SPEED);

                    break;

                case "Right":

                    tile1.setXPos(tile1.getXPos() - GlobalVariables.TILE_PUSHBACK_SPEED);

                    break;

                case "Bottom":

                    tile1.setYPos(tile1.getYPos() - GlobalVariables.TILE_PUSHBACK_SPEED);

                    break;
            }
        }
    }
}