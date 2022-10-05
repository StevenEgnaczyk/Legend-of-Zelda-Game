using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemySpriteAndStateFactory
	{

	private Texture2D enemySpritesheet;
	private Texture2D bossSpritesheet;
	
	public static EnemySpriteAndStateFactory instance = new EnemySpriteAndStateFactory();
				
	public static EnemySpriteAndStateFactory Instance
		{
		get
		{
			return instance;
		}
	}
		
	public EnemySpriteAndStateFactory()
	{
		this.enemySpritesheet = Texture2DStorage.getEnemySpritesheet();
        this.bossSpritesheet = Texture2DStorage.getBossSpritesheet();
    }

	public IEnemySprite CreateKeeseSprite()
	{
		return new KeeseSprite(enemySpritesheet);
	}
		
	public IEnemySprite CreateStalfosSprite()
	{
		return new StalfosSprite(enemySpritesheet);
	}
		
	public IEnemySprite CreateGelSprite()
	{
		return new GelSprite(enemySpritesheet);
	}
		
	public IEnemySprite CreateGoriyaSprite()
	{
		return new GelSprite(enemySpritesheet);
	}

	public IEnemySprite CreateBladeTrapSprite()
	{
		return new BladeTrapSprite(enemySpritesheet);
	}

	public IEnemySprite CreateWallmasterSprite()
	{
		return new WallmasterSprite(enemySpritesheet);
	}

	public IEnemySprite CreateAquamentusSprite()
	{
		return new AquamentusSprite(bossSpritesheet);
	}

	public EnemyState CreateEnemyState()
	{
		return new EnemyState();
	}
}
