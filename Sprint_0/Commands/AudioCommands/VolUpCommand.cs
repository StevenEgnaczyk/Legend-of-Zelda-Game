using Microsoft.Xna.Framework.Media;
using System;

public class VolUpCommand : ICommand
{
	public VolUpCommand()
	{
	}

	public void Execute()
	{
//		if(MediaPlayer.Volume <= 1.0f)
		MediaPlayer.Volume += 0.01f;
	}
}
