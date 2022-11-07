using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
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
    public  void manageCollisions(Link link, List<IEnemy> enemies, List<ITile> tiles, List<IItem> items, Inventory userInv)
    {
        //Collisions for link vs enemies, enemies vs block
        foreach (IEnemy enemy in enemies.ToArray()) {
            
            CollisionResponse.collisionResponse(link, enemy);

            foreach (ITile tile in tiles)
            {
                CollisionResponse.collisionResponse(enemy, tile);
            }

            if (userInv.UsingWeapon() != null)
            {
                CollisionResponse.collisionResponse(enemy, userInv);
            }



        }

        //Collisions for link vs blocks
        foreach (ITile tile in tiles)
        {
            CollisionResponse.collisionResponse(link, tile);

            if (userInv.UsingWeapon() != null)
            {
                CollisionResponse.collisionResponse(userInv, tile);
            }

        }

        foreach (IItem item in items.ToArray())
        {
            CollisionResponse.collisionResponse(link, item);
        }
    }

}