using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

public static class Texture2DStorage
{
	// Note that we are not using Game1's ContentLoader here (outside the scope of class methods) since it has not been instantiated yet
	private static Texture2D linkSpriteSheet;
	private static Texture2D NPCSpriteSheet;

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
	private static Texture2D tile1Sprite;
	private static Texture2D tile2Sprite;
	private static Texture2D tile3Sprite;
	private static Texture2D tile4Sprite;
	private static Texture2D tile5Sprite;
	private static Texture2D tile6Sprite;
	private static Texture2D tile7Sprite;
	private static Texture2D tile8Sprite;
	private static Texture2D tile9Sprite;
	private static Texture2D tile10Sprite;

	// tiles = new Dictionary<string, Texture2D>()
    //     {
    //         { "tile1", c.Load<Texture2D>("tiles/tile1")},
    //         { "tile2", c.Load<Texture2D>("tiles/tile2")},
	// 		{ "tile3", c.Load<Texture2D>("tiles/tile3")},
	// 		{ "tile4", c.Load<Texture2D>("tiles/tile4")},
	// 		{ "tile5", c.Load<Texture2D>("tiles/tile5")},
	// 		{ "tile6", c.Load<Texture2D>("tiles/tile6")},
	// 		{ "tile7", c.Load<Texture2D>("tiles/tile7")},
	// 		{ "tile8", c.Load<Texture2D>("tiles/tile8")},
	// 		{ "tile9", c.Load<Texture2D>("tiles/tile9")},
	// 		{ "tile10", c.Load<Texture2D>("tiles/tile10")}
	// 	};


    // More private static Texture2D fields follow

    // static classes have no constructor, but we need a method to initialize the Texture2D fields
    public static void LoadAllTextures(ContentManager content)
	{
		NPCSpriteSheet = content.Load<Texture2D>("NPCSpriteSheet");
		linkSpriteSheet = content.Load<Texture2D>("Link");

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
    public static Texture2D GetOldManSpriteSheet()
    {
        return NPCSpriteSheet;
    }
    // More public static Texture2D returning methods follow

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

	public static Texture2D GetTile1Sprite()
	{
		return tile1Sprite;
	}
	public static Texture2D GetTile2Sprite()
	{
		return tile2Sprite;
	}
	public static Texture2D GetTile3Sprite()
	{
		return tile3Sprite;
	}
	public static Texture2D GetTile4Sprite()
	{
		return tile4Sprite;
	}
	public static Texture2D GetTile5Sprite()
	{
		return tile5Sprite;
	}
	public static Texture2D GetTile6Sprite()
	{
		return tile6Sprite;
	}
	public static Texture2D GetTile7Sprite()
	{
		return tile7Sprite;
	}
	public static Texture2D GetTile8Sprite()
	{
		return tile8Sprite;
	}
	public static Texture2D GetTile9Sprite()
	{
		return tile9Sprite;
	}
	public static Texture2D GetTile10Sprite()
	{
		return tile10Sprite;
	}
	// More public static Texture2D returning methods follow

	public static Texture2D getEnemySpritesheet()
	{
		return enemySpritesheet;
	}

	public static Texture2D getBossSpriteSheet()
	{
		return bossSpritesheet;
	}

}