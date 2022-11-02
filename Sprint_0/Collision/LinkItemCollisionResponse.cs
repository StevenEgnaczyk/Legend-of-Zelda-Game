using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkItemCollisionResponse
{
    public static void collisionResponse(Link link, IItem item)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         * TO DO: Figure out items vs weapons and get rectangle for items
         */
        Rectangle linkRec = new Rectangle((int)link.xPos, (int)link.yPos, 64, 64);
        Rectangle itemRec = new Rectangle(100, 100, 16, 16);


        /* 
         * If link collides with an item from any direction, he picks it up
         */
        string collisionFace = CollisionDetection.collides(linkRec, itemRec);
        if (collisionFace != "No collision")
        {
            //add a bomb or bow or whatever to link's inventory or do the thing idk

            link.inventory.addItem(item);
        }
    }

}