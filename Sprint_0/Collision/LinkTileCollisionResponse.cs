using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkTileCollisionResponse
{
    public static void collisionResponse(Link link, ITile tile)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int)link.xPos + 8, (int)link.yPos + 8, 48, 48);
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());



        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */

        if (tile.Teleporter())
        {

            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                
                case "Top":
                    int roomToTeleportTop = RoomTeleportationManager.topTeleporter(link.currentRoom);
                    link.xPos = 500;
                    link.yPos = 700;
                    link.roomManager.loadRoom(roomToTeleportTop);
                    break;

                case "Left":
                    int roomToTeleportLeft = RoomTeleportationManager.leftTeleporter(link.currentRoom);
                    link.xPos = 775;
                    link.yPos = 500;
                    link.roomManager.loadRoom(roomToTeleportLeft);

                    break;

                case "Right":

                    int roomToTeleportRight = RoomTeleportationManager.rightTeleporter(link.currentRoom);
                    link.xPos = 175;
                    link.yPos = 525;
                    link.roomManager.loadRoom(roomToTeleportRight);

                    break;

                case "Bottom":
                    int roomToTeleportBottom = RoomTeleportationManager.bottomTeleporter(link.currentRoom);
                    link.xPos = 500;
                    link.yPos = 250;
                    link.roomManager.loadRoom(roomToTeleportBottom);

                    break;
            }
        }

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
        if (tile.Pushable())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    link.yPos += link.linkSpeed;
                    int y = tile.getYPos() - 1;
                    tile.setYPos(y);

                    break;

                case "Left":

                    link.xPos += link.linkSpeed;
                    int x = tile.getXPos() - 1;
                    tile.setXPos(x);

                    break;

                case "Right":

                    link.xPos -= link.linkSpeed;
                    int z = tile.getXPos() + 1;
                    tile.setXPos(z);

                    break;

                case "Bottom":

                    link.yPos -= link.linkSpeed;
                    int w = tile.getYPos() + 1;
                    tile.setYPos(w);

                    break;
            }
        }
    }
}