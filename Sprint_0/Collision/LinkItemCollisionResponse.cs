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
         */
        Rectangle linkRec = new Rectangle((int)link.xPos, (int)link.yPos, link.getWidth(), link.getHeight());
        Rectangle itemRec = new Rectangle(item.getX(), item.getY(), item.getWidth(), item.getHeight());

        /* 
         * If link collides with an item from any direction, he picks it up
         */
        string collisionFace = CollisionDetection.collides(linkRec, itemRec);
        if (collisionFace != "No Collision")
        {
            //add the item to link's inventory and delete it
            link.inventory.addItem(item);
            item.delete();
        }
    }

}