﻿using Microsoft.Xna.Framework.Media;
using System;

public class VolDownCommand : ICommand
{
	public VolDownCommand()
	{
	}

	public void Execute()
	{
		//decrement mediaPlayer volume by a small amound to make volume control smooth
		MediaPlayer.Volume -= GlobalVariables.VOLUME_CHANGE;
	}
}
