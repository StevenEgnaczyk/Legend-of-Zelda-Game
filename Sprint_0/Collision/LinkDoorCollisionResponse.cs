using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkDoorCollisionResponse
{

    public static void collisionResponse(Link link, IDoor door, Sprint_0.Game1 game)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int)link.xPos + GlobalVariables.HITBOX_OFFSET, (int)link.yPos + GlobalVariables.HITBOX_OFFSET, link.getWidth(), link.getHeight());
        Rectangle tileRec = new Rectangle(door.getXPos(), door.getYPos(), door.getWidth(), door.getHeight());


        ChangeRoomStateCommand roomChange = new ChangeRoomStateCommand(game);

        /*
         * Link doesn't turn when hitting a wall, so this just stops his x or y position
         * from moving further into the block (instead of turning) 
         * 
         * Need: A special method for the block that gets pushed
         */

        if (door.Locked())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                case "Top":

                    //Unlock the door if link has keys, if not turn him away
                    if (link.hasKeys())
                    {
                        door.Unlock();
                        link.inventory.removeKey();
                    } else
                    {
                        link.yPos += link.linkSpeed;
                    }
                    break;

                case "Left":

                    //Unlock the door if link has keys, if not turn him away
                    if (link.hasKeys())
                    {
                        door.Unlock();
                        link.inventory.removeKey();
                    } else
                    {
                        link.xPos += link.linkSpeed;
                    }
                    break;

                case "Right":

                    //Unlock the door if link has keys, if not turn him away
                    if (link.hasKeys())
                    {
                        door.Unlock();
                        link.inventory.removeKey();
                    } else
                    {
                        link.xPos -= link.linkSpeed;
                    }
                    break;

                case "Bottom":

                    //Unlock the door if link has keys, if not turn him away
                    if (link.hasKeys())
                    {
                        door.Unlock();
                        link.inventory.removeKey();
                    } else
                    {
                        link.yPos -= link.linkSpeed;
                    }
                    break;
            }
        }

        //If the door is a teleporter
        if (door.Teleporter())
        {

            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {
                
                case "Top":

                    //Teleport Link to the new room
                    int roomToTeleportTop = RoomTeleportationManager.topTeleporter(link.currentRoom);
                    if (roomToTeleportTop > 0)
                    {
                        game.link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_TOP;
                        game.link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_TOP;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportTop);
                    }
                    break;

                case "Left":

                    //Teleport Link to the new room
                    int roomToTeleportLeft = RoomTeleportationManager.leftTeleporter(link.currentRoom);
                    if (roomToTeleportLeft > 0)
                    {
                        link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_RIGHT;
                        link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_RIGHT;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportLeft);
                    }
                    break;

                case "Right":

                    //Teleport Link to the new room
                    int roomToTeleportRight = RoomTeleportationManager.rightTeleporter(link.currentRoom);
                    if (roomToTeleportRight > 0)
                    {
                        link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_LEFT;
                        link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_LEFT;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportRight);
                    }
                    break;

                case "Bottom":

                    //Teleport Link to the new room
                    int roomToTeleportBottom = RoomTeleportationManager.bottomTeleporter(link.currentRoom);
                    if (roomToTeleportBottom > 0)
                    {
                        link.xPos = GlobalVariables.LINK_STARTING_X_ENTERING_BOTTOM;
                        link.yPos = GlobalVariables.LINK_STARTING_Y_ENTERING_BOTTOM;
                        game.roomManager.saveRoomInfo();
                        roomChange.Execute(link, roomToTeleportBottom);
                    }
                    break;
            }
        }

        //If the door is closed
        if (door.Closed())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {

                //Move link back
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

        if (door.Bombed())
        {
            string collisionFace = CollisionDetection.collides(linkRec, tileRec);
            switch (collisionFace)
            {

                //Move link back
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

    }
}