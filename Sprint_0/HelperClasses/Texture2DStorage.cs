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
	private static Texture2D deathSpriteSheet;
	private static Texture2D daBabySpriteSheet;
	private static Texture2D startupSpriteSheet;
	private static Texture2D deathScreen;
	private static Texture2D black;

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
		deathSpriteSheet = content.Load<Texture2D>("EnemyDeath");
		daBabySpriteSheet = content.Load<Texture2D>("DaBaby");
		startupSpriteSheet = content.Load<Texture2D>("TitleScreen");
		deathScreen = content.Load<Texture2D>("DeathScreen");
		black = content.Load<Texture2D>("Black");

    }

	//get methods for spritesheets
	public static Texture2D GetDaBaby()
	{
		return black;
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

    internal static Texture2D GetHUDSpriteSheet()
    {
        return hudSpriteSheet;
    }

	public static Texture2D GetDeathSpriteSheet()
	{
		return deathSpriteSheet;
	}

	internal static Texture2D GetStartupSpriteSheet()
	{
		return startupSpriteSheet;
	}

	internal static Texture2D GetDeeathScreenSheet()
	{
		return deathScreen;
	}
}