using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.Player;

public class CollisionManager
{


    /* I assume we only want one instance of a collision manager throughout
     * the entire game, hence the */
    public static CollisionManager instance = new CollisionManger();

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

    public void manageCollisions(Link link, List<IEnemy> enemies, List<Tile> tiles)
    {

        foreach (IEnemy enemy in enemies) {

            CollisionResponse.collisionResponse(link, enemy);
        }

        foreach(Tile tile in tiles)
        {
            CollisionResponse.collisionResponse(link, tile);

        }

    }

}