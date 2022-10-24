using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Player;
using System.Collections.Generic;


public class CollisionManager
{


    /* I assume we only want one instance of a collision manager throughout
     * the entire game, hence the */
    public static CollisionManager instance = new CollisionManager();

    public static CollisionManager Instance
    {
        get
        {
            return instance;
        }
    }

    /* I don't think you need to initialize anything for the class */
    public CollisionManager()
    {
    }


    /* Not very efficient, may want to refactor in the future*/
    public  void manageCollisions(Link link, List<IEnemy> enemies, List<ITile> tiles, List<Item> items)
    {
        //Collisions for link vs enemies, enemies vs block
        foreach (IEnemy enemy in enemies) {

            CollisionResponse.collisionResponse(link, enemy);

            foreach (ITile tile in tiles)
            {
                CollisionResponse.collisionResponse(enemy, tile);
            }

        }

        //Collisions for link vs blocks
        foreach (ITile tile in tiles)
        {
            CollisionResponse.collisionResponse(link, tile);

        }

        foreach (Item item in items)
        {
            CollisionResponse.collisionResponse(link, item);
        }
    }

}