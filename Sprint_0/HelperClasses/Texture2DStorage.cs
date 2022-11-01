using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

public static class Texture2DStorage
{
    public static int BLOCK_WIDTH = 64;
    public static int BLOCK_HEIGHT = 64;

    // Note that we are not using Game1's ContentLoader here (outside the scope of class methods) since it has not been instantiated yet
    private static Texture2D linkSpriteSheet;
	private static Texture2D NPCSpriteSheet;
	private static Texture2D itemSpriteSheet;
	private static Texture2D enemySpritesheet;
	private static Texture2D bossSpritesheet;
	private static Texture2D dungeonSpritesheet;
    private static Texture2D hudSpriteSheet;


    // More private static Texture2D fields follow

    // static classes have no constructor, but we need a method to initialize the Texture2D fields
    public static void LoadAllTextures(ContentManager content)
	{
		NPCSpriteSheet = content.Load<Texture2D>("NPCSpriteSheet");
		linkSpriteSheet = content.Load<Texture2D>("Link");
		itemSpriteSheet = content.Load<Texture2D>("ItemSpritesheet");
		enemySpritesheet = content.Load<Texture2D>("enemiesSpriteSheet");
		bossSpritesheet = content.Load<Texture2D>("bossSpritesheet");
		dungeonSpritesheet = content.Load<Texture2D>("dungeonTileset");
        hudSpriteSheet = content.Load<Texture2D>("HUDSpritesheet");


        /*
		 * item1Sprite = content.Load<Texture2D>("item1");
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
		 * 
		 */

    }

    public static Texture2D GetLinkSpriteSheet()
	{
		return linkSpriteSheet;
	}
    public static Texture2D GetOldManSpriteSheet()
    {
        return NPCSpriteSheet;
    }

	public static Texture2D getEnemySpritesheet()
	{
		return enemySpritesheet;
	}

	public static Texture2D getBossSpritesheet()
	{
		return bossSpritesheet;
	}

	public static Texture2D GetItemSpritesheet()
	{
		return itemSpriteSheet;
	}

    public static Texture2D GetDungeonTileset()
    {
        return dungeonSpritesheet;
    }

    internal static Rectangle getBlockRect(int blockID)
    {
        return blockID switch
        {
            1 => new Rectangle(1, 192, 16, 16),
            2 => new Rectangle(81, 355, 16, 16),
            3 => new Rectangle(244, 272, 16, 16),
            4 => new Rectangle(244, 438, 16, 16),
            5 => new Rectangle(260, 272, 16, 16),
            6 => new Rectangle(308, 240, 16, 16),
            7 => new Rectangle(81, 898, 16, 16),
            8 => new Rectangle(97, 470, 16, 16),
            9 => new Rectangle(81, 355, 16, 16),
            _ => new Rectangle(521, 84, 16, 16),
        };
    }

    internal static Texture2D GetHUDSpriteSheet()
    {
        return hudSpriteSheet;
    }
}