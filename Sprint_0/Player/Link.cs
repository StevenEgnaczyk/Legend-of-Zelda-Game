public class Link
{
    public ILinkState state;
    public LinkSprite link;

    public Link()
    {
        state = new RightMovingLinkState(this);
    }

    public void TurnLeft()
    {
        state.turnLeft();
    }

    public void TurnRight()
    {
        state.turnRight();
    }

    public void TurnUp()
    {
        state.turnUp();
    }

    public void TurnDown()
    {
        state.turnDown();
    }

    public void move(int x, int y)
    {

    }


    // Draw and other methods omitted
}