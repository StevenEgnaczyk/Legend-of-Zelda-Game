using Microsoft.Xna.Framework.Media;
using System;

public class VolDownCommand : ICommand
{
	public VolDownCommand()
	{
	}

	public void Execute()
	{
		MediaPlayer.Volume -= 0.01f;
	}
}
