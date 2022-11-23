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


    /* 
     * Link Collisions
     */
    public static void collisionResponse(Link link, ITile tile, Sprint_0.Game1 game)
    {
        LinkTileCollisionResponse.collisionResponse(link, tile, game);
    }

    public static void collisionResponse(Link link, IEnemy enemy, Game1 game)
    {
        LinkEnemyCollisionResponse.collisionResponse(link, enemy, game);
    }

    public static void collisionResponse(Link link, IItem item)
    {
        LinkItemCollisionResponse.collisionResponse(link, item);
    }

    public static void collisionResponse(Link link, IDoor door, Sprint_0.Game1 game)
    {
        LinkDoorCollisionResponse.collisionResponse(link, door, game);
    }

    /* 
     * Enemy Collisions
     */
    public static void collisionResponse(IEnemy enemy, ITile tile)
    {
        EnemyTileCollisionResponse.collisionResponse(enemy, tile);
    }

    public static void collisionResponse(IEnemy enemy, Link link)
    {
        EnemyWeaponCollisionResponse.collisionResponse(enemy, link);
    }

    public static void collisionResponse(IEnemy enemy, IDoor door)
    {
        EnemyDoorCollisionResponse.collisionResponse(enemy, door);
    }

    /*
     *  Weapon Collisions 
     */
    public static void collisionResponse(Inventory userInv, IDoor door)
    {
        WeaponDoorCollisionResponse.collisionResponse(userInv, door);
    }

    public static void collisionResponse(Inventory userInv, ITile tile)
    {
        WeaponTileCollisionResponse.collisionResponse(userInv, tile);
    }
    
    /* 
     * Tile Collisions
     */
    public static void collisionResponse(ITile tile1, ITile tile2)
    {
        TileTileCollisionResponse.collisionResponse(tile1, tile2);
    }
    public static void collisionResponse(ITile tile, IDoor door)
    {
        TileDoorCollisionResponse.collisionResponse(tile, door);
    }
}