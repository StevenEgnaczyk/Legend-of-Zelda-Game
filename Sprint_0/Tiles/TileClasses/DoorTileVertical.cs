using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class DoorTileVertical : ITile
{
    private int xPosition;
    private int yPosition;

    private int width;
    private int height;

    private bool isPushable;
    private bool isWalkable;
    private bool isTeleport;
    private bool isLocked;

    public enum Location
    {
        left,
        right,
    }

    private Location location;

    public DoorTileVertical(int xPos, int yPos, bool locked, Location location)
    {
        if (location == Location.right && !locked)
        {
            this.xPosition = xPos + 32;
        }
        else
        {
            this.xPosition = xPos;
        }
        this.yPosition = yPos;

        if (location == Location.left && !locked)
        {
            this.width = 32;
        } else
        {
            this.width = 64;
        }
        this.height = 64;

        this.isPushable = false;
        this.isWalkable = true;
        this.isLocked = locked;
        this.isTeleport = !locked;
        this.location = location;
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
    public bool Pushable()
    {
        return isPushable;
    }

    public bool Walkable()
    {
        return isWalkable;
    }

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
        isLocked = false;
        isTeleport = true;
    }
}