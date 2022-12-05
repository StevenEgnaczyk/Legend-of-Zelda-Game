using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemyState
{
    //required type properties
    public int facingDirection { get; set; }

    //required methods for interface
    void update();
    void moveLeft(IEnemy e);
    void moveRight(IEnemy e);
    void moveUp(IEnemy e);
    void moveDown(IEnemy e);
    void shootProjectile(IEnemy e);
    void idle(IEnemy e);
    void hurt(IEnemy e);

}