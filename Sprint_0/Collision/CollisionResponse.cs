using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0.LinkPlayer;
using Sprint_0.Interfaces;
using Sprint_0.Collision;
using System.Collections.Generic;
using Sprint_0;

public class CollisionResponse
{

    public static CollisionResponse instance = new CollisionResponse();

    public CollisionResponse()
    {
    }


    /* Link Tile Collisions */
    public static void collisionResponse(Link link, ITile tile, Sprint_0.Game1 game, List<ITile> tiles)
    {
        LinkTileCollisionResponse.collisionResponse(link, tile, game, tiles);
    }

    /* Link Enemy Collisions */
    public static void collisionResponse(Link link, IEnemy enemy, Game1 game)
    {
        LinkEnemyCollisionResponse.collisionResponse(link, enemy, game);
    }

    /* Link Item Collisions */
    public static void collisionResponse(Link link, IItem item)
    {
        LinkItemCollisionResponse.collisionResponse(link, item);
    }

    /* Enemy Tile Collisions */
    public static void collisionResponse(IEnemy enemy, ITile tile)
    {
        EnemyTileCollisionResponse.collisionResponse(enemy, tile);
    }

    /* Enemy Link Collisions */
    public static void collisionResponse(IEnemy enemy, Link link)
    {
        EnemyWeaponCollisionResponse.collisionResponse(enemy, link);
    }

    /* Weapon Tile Collisions */
    public static void collisionResponse(Inventory userInv, ITile tile)
    {
        WeaponTileCollisionResponse.collisionResponse(userInv, tile);
    }

    /* Link Door Collisions */
    public static void collisionResponse(Link link, IDoor door, Sprint_0.Game1 game)
    {
        LinkDoorCollisionResponse.collisionResponse(link, door, game);
    }

    /* Weapon Door Collisions */
    public static void collisionResponse(Inventory userInv, IDoor door)
    {
        WeaponDoorCollisionResponse.collisionResponse(userInv, door);
    }

    /* Enemy Door Collisions */
    public static void collisionResponse(IEnemy enemy, IDoor door)
    {
        EnemyDoorCollisionResponse.collisionResponse(enemy, door);
    }
    
    /* Tile to Tile collision */
    public static void collisionResponse(ITile tile1, ITile tile2)
    {
        TileTileCollisionResponse.collisionResponse(tile1, tile2);
    }
}