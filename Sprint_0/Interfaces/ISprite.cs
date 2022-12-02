using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public interface ISprite
{
    //required methods for interface
    void Update();

    void Draw(SpriteBatch _spriteBatch);
}
