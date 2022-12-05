using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IDoor
{
    //door type list
    public enum state
    {
        blank,
        open,
        locked,
        closed,
        cracked,
        bombed,
        invisible,
        dababy,
    }

    //IDoor var properties
    public int getXPos();
    public int getYPos();
    public void setXPos(int x);
    public void setYPos(int y);

    public int getWidth();
    public int getHeight();

    public bool Teleporter();

    public void Draw(SpriteBatch _spriteBatch);
    bool Locked();

    bool Cracked();
    void Unlock();

    void Bomb();

    void Update();
    bool Closed();

    int getFullWidth() { return 128; }
    int getFullHeight() { return 128; }

}