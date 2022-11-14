using System;

public class IdleEnemyState : IEnemyState
{

    private IEnemy enemy;

    private int facingDirection { get; }


    public IdleEnemyState(IEnemy e)
    {
        enemy = e;
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
        enemy.state = new HurtEnemyState(enemy, facingDirection);
    }

    public void shootProjectile(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, facingDirection);
    }

    public void idle(IEnemy enemy) { }

    public void update() { }

}