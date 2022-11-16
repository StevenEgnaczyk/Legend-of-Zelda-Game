using System;

public class IdleEnemyState : IEnemyState
{

    private IEnemy enemy;

    public int facingDirection { get; set; }


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

    public void idle(IEnemy enemy) {
        update();
    }

    public void update() 
    {
        if (enemy.randTime == 0)
        {
            Random r = new Random();
            enemy.randTime = r.Next(5, 20);

            enemy.changeToRandState();

        }
        else
        {
            enemy.randTime--;
        }
    }

}