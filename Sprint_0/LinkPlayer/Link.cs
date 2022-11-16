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
    public Inventory inventory;
    public int currentRoom;

    public float xPos, yPos;
    public int linkSpeed = 3;
    private float linkHealth;
    private float linkMaxHealth = 3.0f;

    

    public Link(SpriteBatch spriteBatch)
    {

        state = new DownMovingLinkState(this);
        inventory = new Inventory(this);

        linkHealth = linkMaxHealth;

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
        inventory.Update();
    }

    public void Die()
    {
        inventory = new Inventory(this);
        linkHealth = linkMaxHealth;
        xPos = 500;
        yPos = 500;
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        if (inventory.primaryWeaponManager.usingPrimaryWeapon)
        {
            inventory.primaryWeaponManager.Draw(_spriteBatch);
        } else if (inventory.secondaryWeaponManager.usingSecondaryWeapon)
        {
            inventory.secondaryWeaponManager.Draw(_spriteBatch);
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
        inventory.secondaryWeaponManager.UseSecondaryWeapon();
    }

    internal void UsePrimaryWeapon()
    {
        inventory.primaryWeaponManager.UsePrimaryWeapon();
    }

    public float getHealth()
    {
        return linkHealth;
    }

    public float getMaxHealth()
    {
        return linkMaxHealth;
    }

    public void takeDamage()
    {
        linkHealth -= 0.5f;
        state = new DamagedLinkState(this);
        AudioStorage.GetLinkHurt().Play();
        if (linkHealth <= 0)
        {
            AudioStorage.GetLinkDie().Play();
            Die();
        }
    }
    public void gainHealth()
    {
        linkHealth++;
        if (linkHealth >= linkMaxHealth)
        {
            linkHealth = linkMaxHealth;
        }
    }

    internal bool hasKeys()
    {
        return inventory.getKeys() > 0;
    }

    internal int getWidth()
    {
        return 48;
    }

    internal int getHeight()
    {
        return 48;
    }
}