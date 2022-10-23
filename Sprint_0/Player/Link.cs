using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Player;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

public class Link
{
    public ILinkState state;

    public float xPos, yPos;
    public SpriteBatch _spriteBatch;
    public int linkSpeed = 3;
    public userItems inventory;

    public Link()
    {

        state = new DownMovingLinkState(this);
        inventory = new userItems(this);

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
        state.Die();
    }

    public void reset()
    {
        state = new DownMovingLinkState(this);
        inventory = new userItems(this);

        xPos = 500;
        yPos = 500;
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        if (inventory.currentWeapon != null)
        {
            inventory.Draw(_spriteBatch);
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

    internal void UseWoodenSword()
    {
        inventory.UseWoodenSword();
    }

    internal void UseSwordBeam()
    {
        inventory.UseSwordBeam();
    }

    internal void UseBoomerang()
    {
        inventory.UseBoomerang();
    }

    internal void UseBow(String arrowType)
    {
        inventory.UseBow(arrowType);
    }

    internal void UseFire()
    {
        inventory.UseFire();
    }

    internal void UseBomb()
    {
        inventory.UseBomb();
    }
}