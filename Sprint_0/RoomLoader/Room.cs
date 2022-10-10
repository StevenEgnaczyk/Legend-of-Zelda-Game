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
        Debug.WriteLine(roomInformation.ToString());
        drawBackground(spriteBatch, roomInformation);
    }

    private void drawBackground(SpriteBatch spriteBatch, List<int> roomInformation)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        spriteBatch.Draw(dungeonTiles, )
       
    }
}