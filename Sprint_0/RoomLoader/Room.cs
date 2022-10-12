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
        List<int> roomInformation = RoomLoader.getRoomInformation(currentRoomIndex);
        drawBackground(spriteBatch, roomInformation);
    }

    private void drawBackground(SpriteBatch spriteBatch, List<int> roomInformation)
    {
        drawDoors(spriteBatch, roomInformation);
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(0);
        Rectangle destRect = new Rectangle(0, 80, bgRect.Width * 4, bgRect.Height * 4);
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