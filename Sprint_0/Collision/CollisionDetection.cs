using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public static class CollisionDetection
{


    public static string collides(Rectangle r1, Rectangle r2)
    {
        string collisionFace = "No Collision";
        
        if (r1.Intersects(r2)) 
        {
            Rectangle intersection = Rectangle.Intersect(r1,r2);
            
            //Left-Right Collision
            if(intersection.Width <= intersection.Height)
            {
                int r1dx = r1.X - intersection.X;

                if(r1dx == 0)
                {
                    collisionFace = "Left";

                } else
                {
                    collisionFace = "Right";

                }

            } else //Top-Bottom Collision
            {
                int r1dy = r1.Y - intersection.Y;

                if(r1dy == 0)
                {
                    collisionFace = "Top";

                } else
                {
                    collisionFace = "Bottom";

                }

            }
        }

        return collisionFace;

    }

}