using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

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

    //
    public void collisionResponse()
    {

    }

}