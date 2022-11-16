using System;

public class ShootingProjectileEnemyState : IEnemyState
{

    private IEnemy enemy;

    public int facingDirection { get; set; }

    public ShootingProjectileEnemyState(IEnemy e, int oldFacingDirection)
    {
        enemy = e;
        
        if(oldFacingDirection < 4)
        {

            /* facingDirection = oldFacigDirection BITWISE OR 12*/ 

        } else
        {

            /* facingDirection = oldFacigDirection BITWISE OR 3*/

        }

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
        enemy.state = new HurtEnemyState(enemy, this.facingDirection);
    }

    public void idle(IEnemy enemy)
    {
        enemy.state = new IdleEnemyState(enemy);
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
            idle(enemy);
        }
    }

}