using Microsoft.Xna.Framework.Media;
using System;

public class VolUpCommand : ICommand
{
	public VolUpCommand()
	{
	}

	public void Execute()
	{
		MediaPlayer.Volume += 0.01f;
	}
}
