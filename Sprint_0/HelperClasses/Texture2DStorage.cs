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
	private static Texture2D itemSpriteSheet;

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

	private static Texture2D enemySpritesheet;
	private static Texture2D bossSpritesheet;

	private static Dictionary<string, Texture2D> tiles;

	private static Texture2D dungeonSpritesheet;


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
    // More public static Texture2D returning methods follow

	public static Texture2D GetItemSpritesheet()
	{
		return itemSpriteSheet;
	}

    public static Texture2D GetDungeonTileset()
    {
        return dungeonSpritesheet;
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

    internal static Rectangle getBlockRect(int blockID)
    {
        switch(blockID)
		{
			case 1:
				return new Rectangle(1, 192, 16, 16);
				break;
            case 2:
                return new Rectangle(81, 355, 16, 16);
                break;
            case 3:
                return new Rectangle(244, 272, 16, 16);
                break;
            case 4:
                return new Rectangle(244, 438, 16, 16);
                break;
            case 5:
                return new Rectangle(260, 272, 16, 16);
                break;
            case 6:
                return new Rectangle(308, 240, 16, 16);
                break;
            case 7:
                return new Rectangle(81, 898, 16, 16);
                break;
            case 8:
                return new Rectangle(97, 470, 16, 16);
                break;
            case 9:
                return new Rectangle(81, 355, 16, 16);
                break;
            default:
				return new Rectangle(0,0, 16, 16);
				break;
		}
    }
}