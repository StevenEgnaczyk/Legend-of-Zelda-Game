using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using Sprint_0;
using System.Collections.Generic;
class LinkSpecialEnemyCollisionResponse
{
    public static void LinkWallmasterCollision(Link link, IEnemy wm, Game1 game)
    {
           //Makes the wallmaster follow link
            if (link.xPos < wm.xPos)
            {
                wm.xPos -= wm.getSpeed();

            }
            else
            {
                wm.xPos += wm.getSpeed();

            }

            if (link.yPos < wm.xPos)
            {
                wm.yPos -= wm.getSpeed();

            }
            else
            {
                wm.yPos += wm.getSpeed();
            }
     }

    public static void LinkBladeTrapCollision(Link link, IEnemy bt, Game1 game)
    {

        //The blade trap moves towards link if in line
        Rectangle linkRec = new Rectangle((int)link.xPos, (int)link.yPos, 64, 64);
        Rectangle btRec = new Rectangle((int)bt.xPos, (int)bt.yPos, bt.getWidth(), bt.getHeight());

        if ((linkRec.Top < btRec.Bottom && btRec.Top < linkRec.Top) ||
            (btRec.Top < linkRec.Bottom && linkRec.Top < btRec.Top))
        {
            if (link.xPos < bt.xPos)
            {
                bt.moveLeft();

            } else
            {
                bt.moveRight();

            }
        } else if ((linkRec.Left < btRec.Right && btRec.Left < linkRec.Left) ||
                    (btRec.Right < linkRec.Left && linkRec.Right < btRec.Right))
        {
            if (link.yPos < bt.yPos)
            {
                bt.moveUp();
            }
            else
            {
                bt.moveDown();
            }
        }
    }
}

