using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;


    public interface IItemState
    {
    void Draw(SpriteBatch spriteBatch);
    public void Next();
        public void Prev();
    void Update();
    // Draw() might also be included here
}
