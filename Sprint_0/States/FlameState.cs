using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata;
using System.Threading;

public class FlameState : IFlameState
{
    private Flame flame;
    public FlameState(Flame flame)
    {
        this.flame = flame;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        Texture2D flameTexture = Texture2DStorage.GetOldManSpriteSheet();
        Rectangle[] sourceRect;       
        sourceRect = new Rectangle[2];
        sourceRect[0] = new Rectangle(52, 11, 16, 16);
        sourceRect[1] = new Rectangle(69, 11, 16, 16);
       
        flame.DrawSprite(spriteBatch, flameTexture, sourceRect[0]);
        flame.DrawSprite(spriteBatch, flameTexture, sourceRect[1]);
        
        
        
    }
    public void Update()
    {
        //switch flame sprite
       

       
    }
}