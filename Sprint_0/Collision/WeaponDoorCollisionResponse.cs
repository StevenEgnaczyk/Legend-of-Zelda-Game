using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Sprint_0.LinkPlayer.LinkInventory;
using Sprint_0;



public class WeaponDoorCollisionResponse
{
    public static void collisionResponse(Inventory userInv, IDoor door)
    {

        Rectangle weaponRec = userInv.getWeapon();
        Rectangle doorRect = new Rectangle(door.getXPos(), door.getYPos(), door.getWidth(), door.getHeight());

        //Stop using the weapon if the weapon collides with a door
        if (!userInv.secondaryWeaponManager.bombSelected()) { 
            string collisionFace = CollisionDetection.collides(weaponRec, doorRect);
            if (collisionFace != "No Collision")
            {
                userInv.StopUsingWeapon();
            }
        }
        else
        {
            string collisionFace = CollisionDetection.collides(weaponRec, doorRect);
            if (door.Cracked())
            {
               
                switch (collisionFace)
                {
                    case "Top":

                        //Unlock the door if link has keys, if not turn him away
                           door.Bomb();
                        break;

                    case "Left":

                        //Unlock the door if link has keys, if not turn him away
                       
                            door.Bomb();
                        break;

                    case "Right":

                        //Unlock the door if link has keys, if not turn him away

                            door.Bomb();

                        break;

                    case "Bottom":

                        //Unlock the door if link has keys, if not turn him away

                            door.Bomb();

                        break;
                }
            }
        }

        
    }
}