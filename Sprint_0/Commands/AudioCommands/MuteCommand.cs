using Microsoft.Xna.Framework.Media;
using System;

public class MuteCommand : ICommand
{
	public MuteCommand()
	{
	}

	public void Execute()
	{
		//change mediaplayer volume to zero
		MediaPlayer.Volume = 0.0f;
	}
}
