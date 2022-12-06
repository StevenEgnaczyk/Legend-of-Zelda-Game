using System;

public class UpMovingEnemyState : IEnemyState
{

    private IEnemy enemy;

    public int facingDirection { get; set; }

    public UpMovingEnemyState(IEnemy e)
    {
        enemy = e;

        facingDirection = 2;
        enemy.yPos -= enemy.getSpeed();


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
        enemy.yPos -= enemy.getSpeed();
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
            enemy.randTime = r.Next(5, 75);

            enemy.changeToRandState();

        } else
        {
            enemy.randTime--;
            moveUp(enemy);
        }
    }

}