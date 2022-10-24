using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Player;
using Sprint_0.Interfaces;

public class CollisionResponse
{

    public static CollisionResponse instance = new CollisionResponse();

    public static CollisionResponse Instance
    {
        get
        {
            return instance;
        }
    }

    /* I don't think you need to initialize anything for the class */
    public CollisionResponse()
    {
    }


    public static void collisionResponse(Link link, ITile tile)
    {
        LinkTileCollisionResponse.collisionResponse(link, tile);
    }

    public static void collisionResponse(Link link, IEnemy enemy)
    {
        LinkEnemyCollisionResponse.collisionResponse(link, enemy);
    }

    public static void collisionResponse(Link link, Item item)
    {
        //TO DO: Implement
    }

    public static void collisionResponse(IEnemy enemy, ITile tile)
    {
        EnemyTileCollisionResponse.collisionResponse(enemy, tile);
    }

    public static void collisionResponse(IEnemy enemy, userItems weapon)
    {
        EnemyWeaponCollisionResponse.collisionResponse(enemy, weapon);
    }

    public static void collisionResponse(userItems weapon, ITile tile)
    {
        WeaponTileCollisionResponse.collisionResponse(weapon, tile);
    }
}