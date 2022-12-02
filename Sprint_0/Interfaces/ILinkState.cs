using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface ILinkState
{
    //required methods for interface
    public void TurnUp();
    public void TurnDown();
    public void TurnLeft();
    public void TurnRight();
    public void Die();
    public void Update();
    public void Draw(SpriteBatch _spriteBatch);
    public void UseWoodenSword();
    public void UseSwordBeam();
    void DrawAttackingLink(SpriteBatch spriteBatch);
}