public class SetDeadPlayerSpriteCommand : ICommand
{
	private Game1 myGame;

	public SetDeadPlayerSpriteCommand(Game1 game)
	{
		myGame = game;
	}

	public void Execute()
	{

		//Change links state to dead
		myGame.setSprite(new DeadPlayerSprite());
	}
}