using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class LinkEnemyCollisionResponse
{
    public static void collisionResponse(Link link, IEnemy enemy)
    {
        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int) link.xPos, (int) link.yPos, 64, 64);
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());


        /*
         * Pushes Link and enemy back so that the he is not overtop the enemy, then changes his
         * state to damaged, and turns him (I'm pretty sure he turns when hurt)
         * 
         * Double check: Enemies don't get damaged when link collides
         * Need: A method that causes Link (and/or enemies) to slide back when hurt
         */
        string collisionFace = CollisionDetection.collides(linkRec, enemyRec);
        switch (collisionFace)
        {
            case "Top":

                //push both objects away so they don't occupy the same space
                link.yPos -= link.linkSpeed * 32;
                enemy.yPos += enemy.getSpeed();
                
                //Make link look hurt
                link.takeDamage();
                
                //I'm pretty sure link changes directions when hurt
                link.TurnDown();
               
                //TO DO: add pushback on link (in link damaged state I think)


                break;

            case "Left":

                link.xPos += link.linkSpeed * 32;
                enemy.xPos -= enemy.getSpeed();

                link.takeDamage();
                
                link.TurnRight();

                break;

            case "Right":

                link.xPos -= link.linkSpeed;
                enemy.xPos += enemy.getSpeed();

                link.takeDamage();
                
                link.TurnLeft();

                break;

            case "Bottom":

                link.yPos += link.linkSpeed;
                enemy.yPos -= enemy.getSpeed();

                link.takeDamage();
                
                link.TurnUp();

                break;
        }
    }
}