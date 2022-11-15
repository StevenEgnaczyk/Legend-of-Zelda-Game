using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System.Collections.Generic;


public class CollisionManager
{

    public static Game1 game;

    /* Only want one instance of the collision manager */
    public static CollisionManager instance = new CollisionManager(game);
    public static CollisionManager Instance
    {
        get
        {
            return instance;
        }
    }

    public CollisionManager(Sprint_0.Game1 game1)
    {
        game = game1;
    }


    /* Manage the collisions between all collidable objects */
    public  void manageCollisions(Link link, List<IDoor> doorList, List<IEnemy> enemies, List<ITile> tiles, List<ITile> pushTiles, List<IItem> items, Inventory userInv)
    {
        //Collisions for enemies between link, tiles, and weapons
        foreach (IEnemy enemy in enemies.ToArray()) {
            
            //Link collisions
            CollisionResponse.collisionResponse(link, enemy, game);

            //Tile collisions
            foreach (ITile tile in tiles)
            {
                CollisionResponse.collisionResponse(enemy, tile);
            }

            foreach (ITile pushTile in pushTiles)
            {
                CollisionResponse.collisionResponse(enemy, pushTile);

            }

            //Weapon collisions
            if (userInv.UsingWeapon())
            {
                CollisionResponse.collisionResponse(enemy, link);
            }
        }

        //Collisions for tiles between link and weapons
        foreach (ITile tile in tiles)
        {
            //Link collisions
            CollisionResponse.collisionResponse(link, tile, game);

            //Weapon collisions
            if (userInv.UsingWeapon())
            {
                CollisionResponse.collisionResponse(userInv, tile);
            }

            foreach (ITile pushTile in pushTiles)
            {
                CollisionResponse.collisionResponse(pushTile, tile);
            }

        }

        foreach (ITile pushTile in pushTiles)
        {
            CollisionResponse.collisionResponse(link, pushTile, game);

        }

        //Collisions for items between link
        foreach (IItem item in items.ToArray())
        {
            //Link collisions
            CollisionResponse.collisionResponse(link, item);
        }

        foreach (IDoor door in doorList.ToArray())
        {
            //Door collisions
            CollisionResponse.collisionResponse(link, door, game);

            //Weapon Collisions
            CollisionResponse.collisionResponse(userInv, door);

            //Enemy Collisions
            foreach (IEnemy enemy in enemies.ToArray())
            {
                CollisionResponse.collisionResponse(enemy, door);
            }
            
        }
    }

}