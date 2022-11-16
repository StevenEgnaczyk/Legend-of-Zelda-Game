using System;

public class LeftMovingEnemyState  : IEnemyState
{

    private IEnemy enemy;


    public int facingDirection { get; set; }

    public LeftMovingEnemyState(IEnemy e)
    {
        enemy = e;
        facingDirection = 8;
        enemy.xPos -= enemy.getSpeed();


    }

    public void moveLeft(IEnemy enemy)
    {
        enemy.xPos -= enemy.getSpeed();
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
            enemy.randTime = r.Next(5, 20);

            enemy.changeToRandState();

        }
        else
        {
            enemy.randTime--;
            enemy.xPos -= enemy.getSpeed();
        }
    }

}