using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class DoorLeft : IDoor
{
    private int xPosition;
    private int yPosition;

    private int width;
    private int height;

    private bool isTeleport;
    private bool isLocked;

    private enum state
    {
        blank,
        open,
        locked,
        closed,
        bombed,
    }

    private state doorState;

    public DoorLeft(int xPos, int yPos, int index)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;

        switch (index)
        {
            case 0:
                doorState = state.blank;
                break;
            case 1:
                doorState = state.open;
                break;
            case 2:
                doorState = state.locked;
                break;
            case 3:
                doorState = state.closed;
                break;
            case 4:
                doorState = state.bombed;
                break;
            default:
                doorState = state.blank;
                break;

        }

        if (this.doorState == state.locked)
        {
            this.width = 64;
            this.height = 64;
        }
        else
        {
            this.width = 32;
            this.height = 64;
        }

        this.isLocked = (this.doorState == state.locked);
        this.isTeleport = (this.doorState == state.open || this.doorState == state.bombed);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    /* Getters for x,y positons as well as width/height */
    public int getXPos()
    {
        return xPosition;
    }

    public int getYPos()
    {
        return yPosition;
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    /* Boolean getters for the tiles main characteristics */

    public bool Teleporter()
    {
        return isTeleport;
    }

    public bool Locked()
    {
        return isLocked;
    }

    /* Setters for the tiles x and y positions */
    public void setXPos(int x)
    {
        this.xPosition = x;
    }
    public void setYPos(int y)
    {
        this.yPosition = y;
    }

    /* Extraneous commands */
    public void Unlock()
    {
        this.width -= 32;
        isLocked = false;
        isTeleport = true;
    }
}