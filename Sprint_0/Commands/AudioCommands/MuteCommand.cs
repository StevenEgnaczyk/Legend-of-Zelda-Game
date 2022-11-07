using Microsoft.Xna.Framework.Media;
using System;

public class MuteCommand : ICommand
{
	public MuteCommand()
	{
	}

	public void Execute()
	{
		MediaPlayer.Volume = 0.0f;
	}
}
