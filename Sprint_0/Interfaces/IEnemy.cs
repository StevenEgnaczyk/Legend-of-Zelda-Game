using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemy
{
    void draw();
    void update();
    void moveLeft();
    void moveRight();
    void Next();
    void Prev();
}
