using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

public class Link
{
    //link properties
    public ILinkState state;
    public Inventory inventory;
    public Sprint_0.Game1 game;
    public int currentRoom;

    public float xPos, yPos;
    public int linkSpeed = 3;
    private float linkHealth;
    private float linkMaxHealth = 3.0f;
    private ChangeToDeathScreenCommand deathScreen;
    private ChangeToWinScreenCommand winScreen;

    private bool invincible;
    private int invinsibilityCounter;


    //set link defaults
    public Link(SpriteBatch spriteBatch, Sprint_0.Game1 game)
    {

        state = new DownMovingLinkState(this);
        inventory = new Inventory(this);
        deathScreen = new ChangeToDeathScreenCommand(game);
        winScreen = new ChangeToWinScreenCommand(game);
        this.game = game;
        linkHealth = linkMaxHealth;
        invincible = false;


        xPos = 500;
        yPos = 500;
    }

    //action methods for state change
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

    //update call for state and inventory
    public void Update()
    {
        if (invincible)
        {
            invinsibilityCounter--;
            if (invinsibilityCounter <= 0)
            {
                invincible = false;
            }
        }

        state.Update();
        inventory.Update();
        if (OutOfBoundsTest.linkOutOfBounds(xPos, yPos))
        {
            Die();
        }
        if (inventory.HasAlbum())
        {
            winScreen.Execute();
            inventory.removeAlbum();
            state = new DownMovingLinkState(this);
            inventory = new Inventory(this);
            linkHealth = linkMaxHealth;
            xPos = 500;
            yPos = 500;
            game.roomManager.reset();
        }
    }

    //reset everything upon death
    public void Die()
    {
        state = new DownMovingLinkState(this);
        inventory.secondaryWeaponManager.reset();
        inventory = new Inventory(this);
        linkHealth = linkMaxHealth;
        xPos = 500;
        yPos = 500;
        game.roomManager.reset();
        deathScreen.Execute();
    }

    //calls respective draws for weapons and link states
    public void Draw(SpriteBatch _spriteBatch)
    {
        if (inventory.primaryWeaponManager.usingPrimaryWeapon)
        {
            inventory.primaryWeaponManager.Draw(_spriteBatch);
        }
        else if (inventory.secondaryWeaponManager.usingSecondaryWeapon)
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

    //initiate use of weapon
    internal void UseSecondaryWeapon()
    {
        inventory.secondaryWeaponManager.UseSecondaryWeapon();
    }

    internal void UsePrimaryWeapon()
    {
        inventory.primaryWeaponManager.UsePrimaryWeapon();
    }

    //gets for heath
    public float getHealth()
    {
        return linkHealth;
    }

    public float getMaxHealth()
    {
        return linkMaxHealth;
    }

    //subtracts from link's health and checks for if he should die
    public void takeDamage()
    {
        if (!invincible)
        {
            invincible = true;
            invinsibilityCounter = 20;
            linkHealth -= 0.5f;
            state = new DamagedLinkState(this);
            AudioStorage.GetLinkHurt().Play();
            if (linkHealth <= 0)
            {
                AudioStorage.GetLinkDie().Play();
                Die();

            }
        }
    }

    //adds to link health, making sure it does not go over link's maximum health
    public void gainHealth()
    {
        linkHealth++;
        if (linkHealth >= linkMaxHealth)
        {
            linkHealth = linkMaxHealth;
        }
    }

    //checks if link has keys
    internal bool hasKeys()
    {
        return inventory.getKeys() > 0;
    }

    //gets for link's width and height
    internal int getWidth()
    {
        return 48;
    }

    internal int getHeight()
    {
        return 48;
    }
}