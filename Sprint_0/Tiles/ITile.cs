using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface ITile
{
    public int getXPos();
    public int getYPos();
    public void setXPos(int x);
    public void setYPos(int y);

    public bool Pushable();

    public bool Walkable();
    public void Draw(SpriteBatch _spriteBatch);
}