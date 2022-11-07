using Microsoft.Xna.Framework.Media;
using System;

public class VolDownCommand : ICommand
{
	public VolDownCommand()
	{
	}

	public void Execute()
	{
//		if(MediaPlayer.Volume >= 0.0f)
		MediaPlayer.Volume -= 0.01f;
	}
}
