public class RightMovingLinkState : ILinkState
{
    private Link link;

    public RightMovingLinkState(Link link)
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
    }

    public void TurnUp()
    {
        link.state = new UpMovingLinkState(link);
    }

    public void TurnDown()
    {
        link.state = new DownMovingLinkState(link);
    }

    public void Die()
    {

    }

    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}