using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using Sprint_0;
using System.Collections.Generic;

public class LinkEnemyCollisionResponse
{
    public static void collisionResponse(Link link, IEnemy enemy, Game1 game)
    {

        bool isNonLethal = enemy.GetType().ToString().Equals("DeathAnimation"); 

        /*
         * See EnemyTileCollisionResponse for explaination and suggestions.
         */
        Rectangle linkRec = new Rectangle((int) link.xPos, (int) link.yPos, 64, 64);
        Rectangle enemyRec = new Rectangle((int)enemy.xPos, (int)enemy.yPos, enemy.getWidth(), enemy.getHeight());

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
                        link.yPos += link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                        enemy.yPos -= enemy.getSpeed();
                        link.TurnDown();
                    }
               

                    //Make link look hurt
                    link.takeDamage();
                    if (enemy.GetType().ToString().Equals("AdamSandlerGolfBall"))
                    {
                        if (link.getHealth() <= 1)
                        {
                            AudioStorage.GetGolfKill().Play();
                        }
                        else
                        {
                            AudioStorage.GetGolfHit().Play();
                        }
                    }

                    if (link.getHealth() <= 0)
                    {
                        //die.Execute();
                    } 
                    break;

                case "Left":

                    float newLinkLeftXPos = link.xPos + link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                    float newLinkLeftYPos = link.yPos;

                    if (!OutOfBoundsTest.itemOutOfBounds(newLinkLeftXPos, newLinkLeftYPos))
                    {

                        //push both objects away so they don't occupy the same space
                        if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                        {
                            link.xPos = newLinkLeftXPos;
                            link.TurnRight();
                        }
                        //Make link look hurt
                        link.takeDamage();
                        link.takeDamage();
                        if (enemy.GetType().ToString().Equals("AdamSandlerGolfBall"))
                        {
                            if (link.getHealth() <= 1)
                            {
                                AudioStorage.GetGolfKill().Play();
                            }
                            else
                            {
                                AudioStorage.GetGolfHit().Play();
                            }
                        }

                        if (link.getHealth() <= 0)
                        {
                            //die.Execute();
                        }
                    }
                    
                    break;

                case "Right":

                    float newLinkRightXPos = link.xPos - link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                    float newLinkRightYPos = link.yPos;

                    if (!OutOfBoundsTest.itemOutOfBounds(newLinkRightXPos, newLinkRightYPos))
                    {
                        //push both objects away so they don't occupy the same space
                        if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                        {
                            link.xPos = newLinkRightXPos;
                            enemy.xPos += enemy.getSpeed();
                            link.TurnLeft();
                        }
                        link.takeDamage();
                        link.takeDamage();
                        if (enemy.GetType().ToString().Equals("AdamSandlerGolfBall"))
                        {
                            if (link.getHealth() <= 1)
                            {
                                AudioStorage.GetGolfKill().Play();
                            }
                            else
                            {
                                AudioStorage.GetGolfHit().Play();
                            }
                        }

                        //Make link look hurt
                        if (link.getHealth() <= 0)
                        {
                            //die.Execute();
                        }
                    }
                    break;
    
              case "Bottom":
    
                    //push both objects away so they don't occupy the same space
                    if (!enemy.GetType().ToString().Equals("GoriyaBoomerang"))
                    {
                        link.yPos -= link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                        enemy.yPos += enemy.getSpeed();
                        link.TurnUp();
                    }
                    

                    link.takeDamage();
                    link.takeDamage();
                    if (enemy.GetType().ToString().Equals("AdamSandlerGolfBall"))
                    {
                        if (link.getHealth() <= 1)
                        {
                            AudioStorage.GetGolfKill().Play();
                        }
                        else
                        {
                            AudioStorage.GetGolfHit().Play();
                        }
                    }

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