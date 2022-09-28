using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

public class EnemySpriteFactory
	{

	private Texture2D enemySpritesheet;
	private Texture2D bossSpritesheet;
	
	private static EnemySpriteFactory instance = new EnemySpriteFactory();
				
	public static EnemySpriteFactory Instance
		{
		get
		{
			return instance;
		}
	}
		
	private EnemySpriteFactory()
		{	
			enemySpriteSheet = Texture2DStorage.getEnemySpritesheet();
			bossSpritesheet = Texture2DStorage.getSpritesheet();

		}
		
		public ISprite CreateKeeseSprite()
		{
			return new KeeseSprite(enemySpritesheet);
		}
		
		public ISprite CreateStalfosSprite()
		{
			return new StalfosSprite(enemySpritesheet);
		}
		
		public ISprite CreateGelEnemySprite()
		{
			return new GelSprite(enemySpritesheet);
		}
		
		public ISprite CreateGoryiaSprite()
		{
			return new GelSprite(enemySpritesheet);
		}

		public ISprite createBladeTrapSprite()
		{
			return new BladeTrapSprite(enemySpritesheet);
		}

		public ISprite CreateWallmasterSprite()
		{
			return new WallmasterSprite(enemySpritesheet);
		}

		public ISprite CreateAquamentusSprite()
		{
			return new AquamentusSprite(bossSpritesheet);
		}
	}
}