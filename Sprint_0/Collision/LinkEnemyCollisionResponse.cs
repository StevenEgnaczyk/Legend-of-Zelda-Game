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
         */
        if(!isNonLethal) { 
            string collisionFace = CollisionDetection.collides(linkRec, enemyRec);
            switch (collisionFace)
            {
                case "Top":

                   //push both objects away so they don't occupy the same space
                    if (!enemy.GetType().ToString().Equals("GoriyaBoomerang")){
                        link.yPos += link.linkSpeed * GlobalVariables.GLOBAL_SPEED_MULTIPLIER;
                        enemy.moveDown();
                        link.TurnDown();
                    }

                    //Make link look hurt   
                    if (enemy.GetType().ToString().Equals("Keese") || enemy.GetType().ToString().Equals("Gel"))
                    {
                        link.takeDamage();
                    }
                    else
                    {
                        link.takeDamage();
                        link.takeDamage();
                    }
                                    
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

                        enemy.die();
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
                        if (enemy.GetType().ToString().Equals("Keese") || enemy.GetType().ToString().Equals("Gel"))
                        {
                            link.takeDamage();
                        }
                        else
                        {
                            link.takeDamage();
                            link.takeDamage();
                        }

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

                            enemy.die();
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

                        //Make link look hurt   
                        if (enemy.GetType().ToString().Equals("Keese") || enemy.GetType().ToString().Equals("Gel"))
                        {
                            link.takeDamage();
                        }
                        else
                        {
                            link.takeDamage();
                            link.takeDamage();
                        }

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

                            enemy.die();
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
                        enemy.moveUp();
                        link.TurnUp();
                    }

                    //Make link look hurt   
                    if (enemy.GetType().ToString().Equals("Keese") || enemy.GetType().ToString().Equals("Gel"))
                    {
                        link.takeDamage();
                    }
                    else
                    {
                        link.takeDamage();
                        link.takeDamage();
                    }

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

                        enemy.die();
                    }

                    //Make link look hurt
                    if (link.getHealth() <= 0)
                    {
                        //die.Execute();
                    }
                    break;
                case "No Collision":

                    if(enemy.GetType().ToString().Equals("Wallmaster"))
                    {
                        LinkSpecialEnemyCollisionResponse.LinkWallmasterCollision(link, enemy, game);

                    } else if (enemy.GetType().ToString().Equals("BladeTrap"))
                    {
                        LinkSpecialEnemyCollisionResponse.LinkBladeTrapCollision(link, enemy, game);

                    }
                   
                    break;
            }
        }
    }
}