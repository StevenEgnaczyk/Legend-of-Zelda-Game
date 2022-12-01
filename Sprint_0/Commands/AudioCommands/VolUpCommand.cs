using Microsoft.Xna.Framework.Media;
using System;

public class VolUpCommand : ICommand
{
	public VolUpCommand()
	{
	}

	public void Execute()
	{
		//increment mediaplayer volume by a small amount to make volume adjustment smooth
		MediaPlayer.Volume += GlobalVariables.VOLUME_CHANGE;
	}
}
