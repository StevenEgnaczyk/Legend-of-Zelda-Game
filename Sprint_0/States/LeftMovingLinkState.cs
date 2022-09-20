public class LeftMovingLinkState : ILinkState
{
    private Link link;

    public LeftMovingLinkState(Link link)
    {
        this.link = link;
        // construct goomba's sprite here too
    }

    public void TurnLeft()
    {
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