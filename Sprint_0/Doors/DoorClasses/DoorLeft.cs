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
    private int location;

    private int width;
    private int height;

    private bool isTeleport;
    private bool isLocked;
    private bool isBombed;

    private IDoor.state doorState;

    public DoorLeft(int xPos, int yPos, int index)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.location = 3;

        //Set the state of the door
        switch (index)
        {
            case 0:
                doorState = IDoor.state.blank;
                break;
            case 1:
                doorState = IDoor.state.open;
                break;
            case 2:
                doorState = IDoor.state.locked;
                break;
            case 3:
                doorState = IDoor.state.closed;
                break;
            case 4:
                doorState = IDoor.state.cracked;
                break;
            case 5:
                doorState = IDoor.state.invisible;
                break;
            default:
                doorState = IDoor.state.blank;
                break;

        }

        //Set the width and height based on the locked/unlocked state
        if (this.doorState == IDoor.state.locked || this.doorState == IDoor.state.blank || this.doorState == IDoor.state.closed || this.doorState == IDoor.state.bombed)
        {
            this.width = GlobalVariables.DOOR_FULL_WIDTH;
            this.height = GlobalVariables.DOOR_FULL_HEIGHT;
        }
        else
        {
            this.width = GlobalVariables.DOOR_FULL_WIDTH/2;
            this.height = GlobalVariables.DOOR_FULL_HEIGHT;
        }

        //Set the locked and teleport variables
        this.isLocked = (this.doorState == IDoor.state.locked);
        this.isTeleport = (this.doorState == IDoor.state.open);
        this.isBombed = (this.doorState == IDoor.state.bombed);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        //Draw the door
        Texture2D doorTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle doorSource = RoomRectStorage.getDoorSourceRect(doorState, location);
        Rectangle doorDest = RoomRectStorage.getDoorDestinationRect(location);
        spriteBatch.Draw(doorTiles, doorDest, doorSource, Color.White);
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

    public bool Cracked()
    {
        return this.doorState == (IDoor.state.cracked);
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
        this.width -= GlobalVariables.DOOR_FULL_WIDTH/2;
        this.doorState = IDoor.state.open;
        Update();
    }

    public void Bomb()
    {
        this.height -= GlobalVariables.DOOR_FULL_HEIGHT / 2;
        this.yPosition += GlobalVariables.DOOR_FULL_HEIGHT / 2;
        doorState = IDoor.state.bombed;
    }
    public void Update()
    {
        this.isLocked = (this.doorState == IDoor.state.locked);
        this.isTeleport = (this.doorState == IDoor.state.open) || (this.doorState == IDoor.state.bombed);
        this.isBombed = (this.doorState == IDoor.state.bombed);
    }

    public bool Closed()
    {
        return (doorState.Equals(IDoor.state.closed) || doorState.Equals(IDoor.state.locked) || doorState.Equals(IDoor.state.blank) || doorState.Equals(IDoor.state.bombed));
    }
}