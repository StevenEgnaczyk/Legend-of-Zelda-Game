using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;

public interface IEnemyState
{
    public int facingDirection { get; set; }

    void update();
    void moveLeft(IEnemy e);
    void moveRight(IEnemy e);
    void moveUp(IEnemy e);
    void moveDown(IEnemy e);
    void shootProjectile(IEnemy e);
    void idle(IEnemy e);
    void hurt(IEnemy e);

}