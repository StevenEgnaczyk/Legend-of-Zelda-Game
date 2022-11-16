using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System.Collections.Generic;

public class LinkTileCollisionResponse
{
    public static void collisionResponse(Link link, ITile tile, Sprint_0.Game1 game, List<ITile> tiles)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int)link.xPos + GlobalVariables.HITBOX_OFFSET, (int)link.yPos + GlobalVariables.HITBOX_OFFSET, link.getWidth(), link.getHeight());
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());


        ChangeRoomStateCommand roomChange = new ChangeRoomStateCommand(game);

        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */

        //If the tile is a teleporter
        if (tile.Teleporter())
        {
            //If the tile is a stair tile
            if (tile.GetType().ToString().Equals("StairTile"))
            {
                //If link is colliding with the stair tile, teleport him
                string collisionFace = CollisionDetection.collides(linkRec, tileRec);
                if (collisionFace != "No Collision")
                {
                    game.link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_UNDERGROUND;
                    game.link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_UNDERGROUND;
                    game.roomManager.saveRoomInfo();
                    roomChange.Execute(link, GlobalVariables.UNDERGROUND_ROOM_ID);
                }

            //If the tile is an underground teleporter
            } else if (tile.GetType().ToString().Equals("UndergroundTeleporter"))
            {
                //If link is colliding with the underground teleporter, teleport him
                string collisionFace = CollisionDetection.collides(linkRec, tileRec);
                if (collisionFace != "No Collision")
                {
                    game.link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_ABOVEGROUND;
                    game.link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_ABOVEGROUND;
                    game.roomManager.saveRoomInfo();
                    roomChange.Execute(link, GlobalVariables.ABOVEGROUND_ROOM_ID);
                }
            }
        }

        //If the tile isn't walkable, push link back
        if (!tile.Walkable())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    link.yPos += link.linkSpeed;

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

        //If the tile is pushable, push it
        if (tile.Pushable())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    link.yPos += link.linkSpeed;
                    int y = tile.getYPos() - GlobalVariables.PUSH_SPEED;
                    tile.setYPos(y);
                    foreach (ITile t in tiles)
                    {
                        CollisionResponse.collisionResponse(tile, t);
                    }
                    PuzzleManager.instance.managePuzzles();
                    break;

                case "Left":

                    link.xPos += link.linkSpeed;
                    int x = tile.getXPos() - GlobalVariables.PUSH_SPEED;
                    tile.setXPos(x);
                    foreach (ITile t in tiles)
                    {
                        CollisionResponse.collisionResponse(tile, t);
                    }
                    PuzzleManager.instance.managePuzzles();
                    break;

                case "Right":

                    link.xPos -= link.linkSpeed;
                    int z = tile.getXPos() + GlobalVariables.PUSH_SPEED;
                    tile.setXPos(z);
                    foreach (ITile t in tiles)
                    {
                        CollisionResponse.collisionResponse(tile, t);
                    }
                    PuzzleManager.instance.managePuzzles();
                    break;

                case "Bottom":

                    link.yPos -= link.linkSpeed;
                    int w = tile.getYPos() + GlobalVariables.PUSH_SPEED;
                    tile.setYPos(w);
                    foreach (ITile t in tiles)
                    {
                        CollisionResponse.collisionResponse(tile, t);
                    }
                    PuzzleManager.instance.managePuzzles();
                    break;
            }
        }
    }
}