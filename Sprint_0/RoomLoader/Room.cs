using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class Room
{
    private int currentRoomIndex;

    public Room(int v)
    {
        this.currentRoomIndex = v;
    }

    internal void draw(SpriteBatch spriteBatch)
    {
        List<List<int>> roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);
        drawBlocks(spriteBatch, roomInformation);
        drawBackground(spriteBatch, roomInformation[0]);
        
    }

    private void drawBlocks(SpriteBatch spriteBatch, List<List<int>> roomInformation)
    {
        for (int i = 1; i < roomInformation.Count; i++)
        {
            drawBlockLine(spriteBatch, roomInformation[i], i - 1);
        }
    }

    private void drawBlockLine(SpriteBatch spriteBatch, List<int> list, int rowNum)
    {
        Texture2D blockSprites = Texture2DStorage.GetDungeonTileset();
        Rectangle blockRect;
        Rectangle destRect;


        for (int i = 0; i < list.Count; i++)
        {
            blockRect = Texture2DStorage.getBlockRect(list[i]);
            destRect = new Rectangle(128 + (i * 64), 320 + 128  + (64 * rowNum), 64, 64);
            spriteBatch.Draw(blockSprites, destRect, blockRect, Color.White);


        }
    }

    private void drawBackground(SpriteBatch spriteBatch, List<int> roomInformation)
    {
        drawDoors(spriteBatch, roomInformation);
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(0);
        Rectangle destRect = new Rectangle(0, 320, bgRect.Width * 4, bgRect.Height * 4);
        spriteBatch.Draw(dungeonTiles, destRect, bgRect, Color.White);
   
    }

    private void drawDoors(SpriteBatch spriteBatch, List<int> roomInformation)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();

        for (int i = 0; i < 4; i++)
        {
            
            Rectangle doorSourceRect = RoomRectStorage.getDoorSourceRect(roomInformation[i], i);
            Rectangle doorDestinationRect = RoomRectStorage.getDoorDestinationRect(i);
            spriteBatch.Draw(dungeonTiles, doorDestinationRect, doorSourceRect, Color.White);
        }

    }
}