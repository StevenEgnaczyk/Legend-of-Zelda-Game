using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;


    public interface IItem
    {
    void Draw(SpriteBatch spriteBatch);
    void Update();

    int getWidth();
    int getHeight();
    int getX();
    int getY();
    void delete();
}
