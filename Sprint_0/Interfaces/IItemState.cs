using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IItemState
{
    public void Next();
    public void Prev();
    public void Update();
    public void Draw(SpriteBatch _spriteBatch);
    // Draw() might also be included here
}