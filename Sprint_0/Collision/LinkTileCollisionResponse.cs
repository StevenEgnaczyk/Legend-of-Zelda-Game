using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkTileCollisionResponse
{
    public static void collisionResponse(Link link, ITile tile, Sprint_0.Game1 game)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int)link.xPos + 8, (int)link.yPos + 8, 48, 48);
        Rectangle tileRec = new Rectangle(tile.getXPos(), tile.getYPos(), tile.getWidth(), tile.getHeight());


        ChangeRoomStateCommand roomChange = new ChangeRoomStateCommand(game);

        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */

        if (tile.Locked())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {

                case "Top":
                    if (link.hasKeys())
                    {
                        tile.Unlock();
                        link.inventory.removeKey();
                    }
                    break;

                case "Left":

                    if (link.hasKeys())
                    {
                        tile.Unlock();
                        link.inventory.removeKey();
                    }
                    break;

                case "Right":

                    if (link.hasKeys())
                    {
                        tile.Unlock();
                        link.inventory.removeKey();
                    }
                    break;

                case "Bottom":

                    if (link.hasKeys())
                    {
                        tile.Unlock();
                        link.inventory.removeKey();
                    }
                    break;
            }
        }
        if (tile.Teleporter())
        {

            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                
                case "Top":
                    int roomToTeleportTop = RoomTeleportationManager.topTeleporter(link.currentRoom);
                    if (roomToTeleportTop > 0)
                    {
                        game.link.xPos = 490;
                        game.link.yPos = 725;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportTop);
                    }
                    break;

                case "Left":
                    
                    int roomToTeleportLeft = RoomTeleportationManager.leftTeleporter(link.currentRoom);
                    if (roomToTeleportLeft > 0)
                    {
                        link.xPos = 850;
                        link.yPos = 550;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportLeft);
                    }
                    break;

                case "Right":
                    
                    int roomToTeleportRight = RoomTeleportationManager.rightTeleporter(link.currentRoom);
                    if (roomToTeleportRight > 0)
                    {
                        link.xPos = 125;
                        link.yPos = 550;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportRight);
                    }
                    break;

                case "Bottom":
                    int roomToTeleportBottom = RoomTeleportationManager.bottomTeleporter(link.currentRoom);
                    if (roomToTeleportBottom > 0)
                    {
                        link.xPos = 475;
                        link.yPos = 350;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportBottom);
                    }
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