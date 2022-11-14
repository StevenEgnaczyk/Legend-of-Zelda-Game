using System;

public class HurtEnemyState : IEnemyState
{

    private IEnemy enemy;

    private int facingDirection { get; }


    public HurtEnemyState(IEnemy e, int oldFacingDirection)
    {
        enemy = e;
        e.health--;

        facingDirection = oldFacingDirection;

    }

    public void moveLeft(IEnemy enemy)
    {
        enemy.state = new LeftMovingEnemyState(enemy);
    }

    public void moveRight(IEnemy enemy)
    {
        enemy.state = new RightMovingEnemyState(enemy);
    }

    public void moveUp(IEnemy enemy)
    {
        enemy.state = new UpMovingEnemyState(enemy);
    }

    public void moveDown(IEnemy enemy)
    {
        enemy.state = new DownMovingEnemyState(enemy);
    }

    public void hurt(IEnemy enemy)
    {
        enemy.health--;
    }

    public void idle(IEnemy enemy)
    {
        enemy.state = new IdleEnemyState(enemy);
    }

    public void shootProjectile(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, facingDirection);
    }

    public void update() {}

}