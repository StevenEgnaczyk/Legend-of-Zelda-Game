using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomManager
{
    private Link link;
    private int roomNumber;
    Room currentRoom;
    SpriteBatch spriteBatch;
    public static int NUM_ROOMS = 18;
    private static int HUD_SIZE = 224;

    //This class calls a new room and manages the switching between different rooms
    public RoomManager(SpriteBatch sb, Link link)
    {
        this.spriteBatch = sb;
        roomNumber = 1;
        this.link = link;
        this.link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
        
    }

    public void drawRoom(SpriteBatch spriteBatch)
    {
        currentRoom.draw(spriteBatch);

    }

    public void Update()
    {
        currentRoom.Update();
    }

    internal void loadRoom(int roomNumber)
    {
        link.currentRoom = roomNumber;
        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
    }

    public void reset()
    {
        roomNumber = 1;
        currentRoom = new Room(roomNumber, spriteBatch, this.link, this);
    }

    public void drawBackground(SpriteBatch spriteBatch, List<List<int>> backgroundInformation)
    {
        drawDoors(spriteBatch, backgroundInformation[0]);
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle bgRect = RoomRectStorage.getBasicRoom(roomNumber);
        Rectangle destRect = new(0, HUD_SIZE + ((176 - bgRect.Height) * 4), bgRect.Width * 4, bgRect.Height * 4);
        spriteBatch.Draw(dungeonTiles, destRect, bgRect, Color.White);

    }

    public void drawDoors(SpriteBatch spriteBatch, List<int> doorInformation)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();

        for (int i = 0; i < 4; i++)
        {

            Rectangle doorSourceRect = RoomRectStorage.getDoorSourceRect(doorInformation[i], i);
            Rectangle doorDestinationRect = RoomRectStorage.getDoorDestinationRect(i);
            spriteBatch.Draw(dungeonTiles, doorDestinationRect, doorSourceRect, Color.White);
        }

    }

    public void drawDoor(int newDoorTexture, int doorIndex)
    {
        Texture2D dungeonTiles = Texture2DStorage.GetDungeonTileset();
        Rectangle doorSourceRect = RoomRectStorage.getDoorSourceRect(newDoorTexture, doorIndex);
        Rectangle doorDestinationRect = RoomRectStorage.getDoorDestinationRect(0);
        spriteBatch.Draw(dungeonTiles, doorDestinationRect, doorSourceRect, Color.White);

    }
}

