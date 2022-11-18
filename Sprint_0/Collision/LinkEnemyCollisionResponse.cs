using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using Sprint_0;

public class LinkEnemyCollisionResponse
{
    public static void collisionResponse(Link link, IEnemy enemy, Game1 game)
    {

        bool isNonLethal = enemy.GetType().ToString().Equals("DeathAnimation"); 

        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int) link.xPos, (int) link.yPos, 64, 64);
        Rectangle enemyRec = new Rectangle(enemy.xPos, enemy.yPos, enemy.getWidth(), enemy.getHeight());

        //ChangeToDeathScreenCommand die = new ChangeToDeathScreenCommand(game);

        /*
         * Pushes Link and enemy back so that the he is not overtop the enemy, then changes his
         * state to damaged, and turns him (I'm pretty sure he turns when hurt)
         * 
         * Need: A method that causes Link (and/or enemies) to slide back when hurt
         */
        if(!isNonLethal) { 
            string collisionFace = CollisionDetection.collides(linkRec, enemyRec);
            switch (collisionFace)
            {
                case "Top":

                   //push both objects away so they don't occupy the same space
                    if (!enemy.GetType().ToString().Equals("GoriyaBoomerang")){
                        link.yPos -= link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                        enemy.yPos += enemy.getSpeed();
                        link.TurnDown();
                    }
               

                    //Make link look hurt
                    link.takeDamage();
                

                    if (link.getHealth() <= 0)
                    {
                        //die.Execute();
                    } 
                    break;

                case "Left":

                    //push both objects away so they don't occupy the same space
                    if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                    {
                        link.xPos += link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                        enemy.xPos -= enemy.getSpeed();
                        link.TurnRight();
                    }
                    //Make link look hurt
                    link.takeDamage();
                

                    if (link.getHealth() <= 0)
                    {
                        //die.Execute();
                    }
                    break;

                case "Right":

                   //push both objects away so they don't occupy the same space
                   if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                   {
                       link.xPos -= link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                       enemy.xPos += enemy.getSpeed();
                       link.TurnLeft();
                   }
                   link.takeDamage();
                

                   //Make link look hurt
                   if (link.getHealth() <= 0)
                   {
                        //die.Execute();
                    }
                    break;
    
              case "Bottom":
    
                    //push both objects away so they don't occupy the same space
                    if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                    {
                        link.yPos += link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                         enemy.yPos -= enemy.getSpeed();
                        link.TurnUp();
                    }
                    

                    link.takeDamage();
               

                    //Make link look hurt
                    if (link.getHealth() <= 0)
                    {
                        //die.Execute();
                    }
                    break;
            }
        }
    }
}