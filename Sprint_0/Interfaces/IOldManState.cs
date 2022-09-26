using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IOldManState
{
    public void Update();
    public void Draw(SpriteBatch _spriteBatch);
}