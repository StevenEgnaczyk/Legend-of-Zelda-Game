using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Link
{
    public ILinkState state;
    public userInventory inventory;
    public int currentRoom;

    public float xPos, yPos;
    public int linkSpeed = 3;
    private float linkHealth = 3.0f;
    

    public Link()
    {

        state = new DownMovingLinkState(this);
        inventory = new userInventory(this);
        inventory.weaponManager = new userWeapons(this);

        xPos = 500;
        yPos = 500;
    }

    public void TurnLeft()
    {
        state.TurnLeft();
    }

    public void TurnRight()
    {
        state.TurnRight();
    }

    public void TurnUp()
    {
        state.TurnUp();
    }

    public void TurnDown()
    {
        state.TurnDown();
    }

    public void Update()
    {
        state.Update();
        inventory.weaponManager.Update();
    }

    public void Die()
    {
        state.Die();
    }

    public void reset()
    {
        state = new DownMovingLinkState(this);
        inventory.weaponManager = new userWeapons(this);

        xPos = 500;
        yPos = 500;
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        if (inventory.weaponManager.usingWeapon)
        {
            inventory.weaponManager.Draw(_spriteBatch);
        }
        else
        {
            state.Draw(_spriteBatch);
        }
        
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D linkSprite, Rectangle sourceRect)
    {
        Rectangle destinationRect = new Rectangle((int)xPos, (int)yPos, sourceRect.Width * 4, sourceRect.Height * 4);
        _spriteBatch.Draw(linkSprite, destinationRect, sourceRect, Color.White);
    }

    public void DrawSprite(SpriteBatch _spriteBatch, Texture2D linkSprite, Rectangle sourceRect, int xOffset, int yOffset)
    {
        Rectangle destinationRect = new Rectangle((int)(xPos + xOffset), (int)(yPos + yOffset), sourceRect.Width * 4, sourceRect.Height * 4);
        _spriteBatch.Draw(linkSprite, destinationRect, sourceRect, Color.White);
    }

    internal void UseSecondaryWeapon()
    {
        inventory.weaponManager.UseSecondaryWeapon();
    }

    internal void UsePrimaryWeapon()
    {
        inventory.weaponManager.UsePrimaryWeapon();
    }
}