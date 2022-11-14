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

    public int getWidth();
    public int getHeight();

    public bool Pushable();
    public bool Walkable();
    public bool Teleporter();

    public void Draw(SpriteBatch _spriteBatch);
    bool Locked();
    void Unlock();
}