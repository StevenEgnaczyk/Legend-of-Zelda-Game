using System;

public class RightMovingEnemyState : IEnemyState
{

    private IEnemy enemy;

    private int facingDirection { get; }

    public RightMovingEnemyState(IEnemy e)
    {
        enemy = e;
        facingDirection = 4;

    }

    public void moveLeft(IEnemy enemy)
    {
        enemy.state = new LeftMovingEnemyState(enemy);
    }

    public void moveRight(IEnemy enemy)
    {
        enemy.xPos += enemy.getSpeed();
    }

    public void moveUp(IEnemy enemy)
    {
        enemy.state = new UpMovingEnemyState(enemy);
    }

    public void moveDown(IEnemy enemy)
    {
        enemy.state = new DownMovingEnemyState(enemy);
    }

    public void idle(IEnemy enemy)
    {
        enemy.state = new IdleEnemyState(enemy);
    }

    public void hurt(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, this.facingDirection);
    }

    public void shootProjectile(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, this.facingDirection);
    }

    public void update()
    {

        if (enemy.randTime == 0)
        {
            Random r = new Random();
            enemy.randTime = r.Next(50, 200);

            enemy.changeToRandState();

        }
        else
        {
            enemy.randTime--;
            moveRight(enemy);
        }
    }

}