using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class RoomRectStorage
{
    //int for the HUD offset
    private static int HUDHeight = 224;

    private static List<Rectangle> basicRoomRect = new List<Rectangle>()
    {
        new Rectangle(421, 1009, 256, 160),
        new Rectangle(521, 11, 256, 176),
        new Rectangle(912, 818, 256, 176),
        
    };

    private static Rectangle startupSourceRect = new Rectangle(0, 0, 1280, 720);
    private static Rectangle startupDestRect = new Rectangle(0, 0, 1024, 1024);

    private static Rectangle gameOverSourceRect = new Rectangle(0, 0, 1280, 1280);
    private static Rectangle gameOverDestRect = new Rectangle(225, 350, 720, 720);
    
    //get methods for rectangles, some of which also serve to store the rectangles
    public static Rectangle getBasicRoom(int backgroundIndex)
    {

        return backgroundIndex switch
        {
            0 => basicRoomRect[0],
            1 => basicRoomRect[1],
            2 => basicRoomRect[2],
            _ => basicRoomRect[0],
        };
    }

    internal static Rectangle getDoorSourceRect(IDoor.state doorState, int doorPos)
    {
        switch(doorPos)
        {
            case 0:
                switch(doorState)
                {
                    case IDoor.state.blank:
                        return new Rectangle(815, 11, 32, 32);
                    case IDoor.state.open:
                        return new Rectangle(848, 11, 32, 32);
                    case IDoor.state.locked:
                        return new Rectangle(881, 11, 32, 32);
                    case IDoor.state.closed:
                        return new Rectangle(914, 11, 32, 32);
                    case IDoor.state.cracked:
                        return new Rectangle(980, 11, 32, 32);
                    case IDoor.state.bombed:
                        return new Rectangle(947, 11, 32, 32);
                    case IDoor.state.invisible:
                        return new Rectangle(782, 110, 32, 32); 
                    default:
                        break;
                };
                break;
            case 1:
                switch (doorState)
                {
                    case IDoor.state.blank:
                        return new Rectangle(815, 44, 32, 32);
                    case IDoor.state.open:
                        return new Rectangle(848, 44, 32, 32);
                    case IDoor.state.locked:
                        return new Rectangle(881, 44, 32, 32);
                    case IDoor.state.closed:
                        return new Rectangle(914, 44, 32, 32);
                    case IDoor.state.cracked:
                        return new Rectangle(980, 44, 32, 32);
                    case IDoor.state.bombed:
                        return new Rectangle(947, 44, 32, 32);
                    case IDoor.state.invisible:
                        return new Rectangle(782, 110, 32, 32);
                    default:
                        break;
                };
                break;
            case 2:
                switch (doorState)
                {
                    case IDoor.state.blank:
                        return new Rectangle(815, 77, 32, 32);
                    case IDoor.state.open:
                        return new Rectangle(848, 77, 32, 32);
                    case IDoor.state.locked:
                        return new Rectangle(881, 77, 32, 32);
                    case IDoor.state.closed:
                        return new Rectangle(914, 77, 32, 32);
                    case IDoor.state.cracked:
                        return new Rectangle(980, 77, 32, 32);
                    case IDoor.state.bombed:
                        return new Rectangle(947, 77, 32, 32);
                    case IDoor.state.invisible:
                        return new Rectangle(782, 110, 32, 32);
                    default:
                        break;
                };
                break;
            case 3:
                switch (doorState)
                {
                    case IDoor.state.blank:
                        return new Rectangle(815, 110, 32, 32);
                    case IDoor.state.open:
                        return new Rectangle(848, 110, 32, 32);
                    case IDoor.state.locked:
                        return new Rectangle(881, 110, 32, 32);
                    case IDoor.state.closed:
                        return new Rectangle(914, 110, 32, 32);
                    case IDoor.state.cracked:
                        return new Rectangle(980, 110, 32, 32);
                    case IDoor.state.bombed:
                        return new Rectangle(947, 110, 32, 32);
                    case IDoor.state.invisible:
                        return new Rectangle(782, 110, 32, 32);
                    default:
                        break;
                };
                break;
            default:
                break;
        }

        return new Rectangle(0, 0, 0, 0);
        
    }

    internal static Rectangle getBlockRect(int blockID)
    {
        return blockID switch
        {
            0 => new Rectangle(3, 145, 16, 16),
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

    internal static Rectangle getDoorDestinationRect(int doorPos)
    {
        switch(doorPos)
        {
            case 0:
                //Top
                return new Rectangle((112 * 4), HUDHeight, 128, 128);
            case 1:
                //Right
                return new Rectangle((224 * 4), (72 * 4) + HUDHeight, 128, 128);
            case 2:
                //Bottom
                return new Rectangle((112 * 4), (144 * 4) + HUDHeight, 128, 128);
            case 3:
                //Left
                return new Rectangle(0, (72 * 4) + HUDHeight, 128, 128);
                
            default:
                throw new NotImplementedException();

        }
    }

    internal static Rectangle getStartupSourceRect()
    {
        return startupSourceRect;
    }

    internal static Rectangle getStartupDestRect()
    {
        return startupDestRect;
    }

    internal static Rectangle getGameOverSourceRect()
    {
        return gameOverSourceRect;
    }

    internal static Rectangle getGameOverDestRect()
    {
        return gameOverDestRect;
    }
}
