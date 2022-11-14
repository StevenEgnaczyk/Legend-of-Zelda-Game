using System;

public class DownMovingEnemyState : IEnemyState
{

    private IEnemy enemy;

    /* Bitmap of facing directions:
            1110 = 14 = Shooting Up
            1101 = 13 = Shooting Down
            1011 = 11 = Shooting Left
            0111 = 7 = Shooting Right 
            1000 = 8 = Walking left
            0100 = 4 = Walking Right
            0010 = 2 = Walking Up
            0001 = 1 = Walking down*/
    private int facingDirection { get; }

    public DownMovingEnemyState(IEnemy e)
    {
        enemy = e;
        facingDirection = 1; // = 0001 = Walking down

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
        enemy.yPos += enemy.getSpeed();
    }

    public void hurt(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, facingDirection);
    }

    public void idle(IEnemy enemy)
    {
        enemy.state = new IdleEnemyState(enemy);
    }

    public void shootProjectile(IEnemy enemy)
    {
        enemy.state = new HurtEnemyState(enemy, facingDirection);
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
            moveDown(enemy);
        }
    }

}