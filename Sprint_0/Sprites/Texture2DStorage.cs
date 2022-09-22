using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;

public static class Texture2DStorage
{
	// Note that we are not using Game1's ContentLoader here (outside the scope of class methods) since it has not been instantiated yet
	private static Texture2D linkSpriteSheet;

	// More private static Texture2D fields follow

	// static classes have no constructor, but we need a method to initialize the Texture2D fields
	public static void LoadAllTextures(ContentManager content)
	{
		//linkSpriteSheet = content.Load<Texture2D>("Link");
	}

	public static Texture2D GetLinkSpriteSheet()
	{
		return linkSpriteSheet;
	}

	// More public static Texture2D returning methods follow

}