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

	private static Texture2D item1Sprite;
	private static Texture2D item2Sprite;
	private static Texture2D item4Sprite;
	private static Texture2D item5Sprite;
	private static Texture2D item6Sprite;
	private static Texture2D item7Sprite;
	private static Texture2D item8Sprite;
	private static Texture2D item9Sprite;
	private static Texture2D item10Sprite;
	private static Texture2D item11Sprite;
	private static Texture2D item12Sprite;
	private static Texture2D item13Sprite;

	// More private static Texture2D fields follow

	// static classes have no constructor, but we need a method to initialize the Texture2D fields
	public static void LoadAllTextures(ContentManager content)
	{
		linkSpriteSheet = content.Load<Texture2D>("Link1");

		item1Sprite = content.Load<Texture2D>("item1");
		item2Sprite = content.Load<Texture2D>("item2");
		item4Sprite = content.Load<Texture2D>("item4");
		item5Sprite = content.Load<Texture2D>("item5");
		item6Sprite = content.Load<Texture2D>("item6");
		item7Sprite = content.Load<Texture2D>("item7");
		item8Sprite = content.Load<Texture2D>("item8");
		item9Sprite = content.Load<Texture2D>("item9");
		item10Sprite = content.Load<Texture2D>("item10");
		item11Sprite = content.Load<Texture2D>("item11");
		item12Sprite = content.Load<Texture2D>("item12");
		item13Sprite = content.Load<Texture2D>("item13");
	}

	public static Texture2D GetLinkSpriteSheet()
	{
		return linkSpriteSheet;
	}

	public static Texture2D GetItem1Sprite()
	{
		return item1Sprite;
	}

	public static Texture2D GetItem2Sprite()
	{
		return item2Sprite;
	}

	public static Texture2D GetItem4Sprite()
	{
		return item4Sprite;
	}

	public static Texture2D GetItem5Sprite()
	{
		return item5Sprite;
	}

	public static Texture2D GetItem6Sprite()
	{
		return item6Sprite;
	}

	public static Texture2D GetItem7Sprite()
	{
		return item7Sprite;
	}

	public static Texture2D GetItem8Sprite()
	{
		return item8Sprite;
	}

	public static Texture2D GetItem9Sprite()
	{
		return item9Sprite;
	}

	public static Texture2D GetItem10Sprite()
	{
		return item10Sprite;
	}

	public static Texture2D GetItem11Sprite()
	{
		return item11Sprite;
	}

	public static Texture2D GetItem12Sprite()
	{
		return item12Sprite;
	}

	public static Texture2D GetItem13Sprite()
	{
		return item13Sprite;
	}
	// More public static Texture2D returning methods follow

}