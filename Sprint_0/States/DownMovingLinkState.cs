public class DownMovingLinkState : ILinkState
{
    private Link link;

    public DownMovingLinkState(Link link)
    {
        this.link = link;
        // construct goomba's sprite here too
    }

    public void TurnLeft()
    {
        link.state = new LeftMovingLinkState(link);
    }

    public void TurnRight()
    {
        link.state = new RightMovingLinkState(link);
    }

    public void TurnUp()
    {
        link.state = new UpMovingLinkState(link);
    }

    public void TurnDown()
    {
    }

    public void Die()
    {

    }
    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}