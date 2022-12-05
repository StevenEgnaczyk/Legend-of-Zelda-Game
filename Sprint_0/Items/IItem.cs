using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;


    public interface IItem
    {

    //required methods for the type
    void Draw(SpriteBatch spriteBatch);
    void Update();

    int getWidth();
    int getHeight();
    float getX();
    float getY();
    void delete();
}
