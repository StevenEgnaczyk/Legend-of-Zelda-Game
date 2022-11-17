using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

namespace Sprint_0.Collision
{
    public class TileDoorCollisionResponse
    {
        public static void collisionResponse(ITile tile, IDoor door)
        {
            /*
             * Use sprite destination rectangles as hitboxes. 
             */
            Rectangle tileRec = new(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());
            Rectangle doorRect = new(door.getXPos(), door.getYPos(), door.getFullWidth(), door.getFullHeight());


            /* 
             * Stops enemies and tiles occupying the same space, then makes sure the enemy 
             * turns away and doesn't collide again (not the same for collisions with link)
             */
                string collisionFace = CollisionDetection.collides(tileRec, doorRect);
                switch (collisionFace)
                {
                    case "Top":

                        //Stopping the enemy from colliding with the tile and change their direction
                        tile.setYPos(tile.getYPos() + GlobalVariables.TILE_PUSHBACK_SPEED);
                        break;

                    case "Left":

                        tile.setXPos(tile.getXPos() + GlobalVariables.TILE_PUSHBACK_SPEED);
                        break;

                    case "Right":

                        tile.setXPos(tile.getXPos() - GlobalVariables.TILE_PUSHBACK_SPEED);
                        break;

                    case "Bottom":

                        tile.setYPos(tile.getYPos() - GlobalVariables.TILE_PUSHBACK_SPEED);
                        break;
                
            }
        }
    }
}