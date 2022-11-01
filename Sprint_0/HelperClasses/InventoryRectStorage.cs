using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class InventoryRectStorage
{
    private static Rectangle baseInventoryDestRect = new Rectangle(0 * 4, 0 * 4, 256 * 4, 89 * 4);
    private static Rectangle baseInventorySourceRect = new Rectangle(1, 11, 256, 88);

    private static Rectangle mapSectionDestRect = new Rectangle(0, baseInventoryDestRect.Height, 256 * 4, 89 * 4);
    private static Rectangle mapSectionSourceRect = new Rectangle(258, 112, 256, 88);

    private static Rectangle emptyCompassSourceRect = new Rectangle(490, 18, 15, 16);
    private static Rectangle emptyCompassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle compassSourceRect = new Rectangle(612, 156, 15, 16);
    private static Rectangle compassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle mapSourceRect = new Rectangle(601, 156, 8, 16);
    private static Rectangle mapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);

    private static Rectangle emptyMapSourceRect = new Rectangle(259, 113, 8, 16);
    private static Rectangle emptyMapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);

    private static List<Rectangle> dungeonMapInformationSourceRects = new List<Rectangle>
    {
        new Rectangle(519, 108, 8, 8),
        new Rectangle(528, 108, 8, 8),
        new Rectangle(537, 108, 8, 8),
        new Rectangle(546, 108, 8, 8),
        new Rectangle(555, 108, 8, 8),
        new Rectangle(564, 108, 8, 8),
        new Rectangle(573, 108, 8, 8),
        new Rectangle(582, 108, 8, 8),
        new Rectangle(591, 108, 8, 8),
        new Rectangle(600, 108, 8, 8),
        new Rectangle(609, 108, 8, 8),
        new Rectangle(618, 108, 8, 8),
        new Rectangle(627, 108, 8, 8),
        new Rectangle(636, 108, 8, 8),
        new Rectangle(645, 108, 8, 8),
        new Rectangle(654, 108, 8, 8)
    };


    private static List<List<Rectangle>> inventoryDungeonMapSourceRects = new List<List<Rectangle>>
    {
        //Dungeon 1 Rectangles
        new List<Rectangle>
        {
            dungeonMapInformationSourceRects[15],
            dungeonMapInformationSourceRects[1],
            dungeonMapInformationSourceRects[2],
            dungeonMapInformationSourceRects[12],
            dungeonMapInformationSourceRects[15],
            dungeonMapInformationSourceRects[9],
            dungeonMapInformationSourceRects[10],
            dungeonMapInformationSourceRects[15],
            dungeonMapInformationSourceRects[7],
            dungeonMapInformationSourceRects[10],
            dungeonMapInformationSourceRects[7],
            dungeonMapInformationSourceRects[1],
            dungeonMapInformationSourceRects[12],
            dungeonMapInformationSourceRects[5],
            dungeonMapInformationSourceRects[2],
            dungeonMapInformationSourceRects[6],
            dungeonMapInformationSourceRects[1]
        },
    };

    private static List<List<Rectangle>> inventoryDungeonMapDestinationRects = new List<List<Rectangle>>
    {
        //Dungeon 1 Rectangles
        new List<Rectangle>
        {
            getDungeonMapDestinationRectangles(3, 7),
            getDungeonMapDestinationRectangles(2, 7),
            getDungeonMapDestinationRectangles(4, 7),
            getDungeonMapDestinationRectangles(3, 6),
            getDungeonMapDestinationRectangles(3, 5),
            getDungeonMapDestinationRectangles(2, 5),
            getDungeonMapDestinationRectangles(4, 5),
            getDungeonMapDestinationRectangles(3, 4),
            getDungeonMapDestinationRectangles(4, 4),
            getDungeonMapDestinationRectangles(5, 4),
            getDungeonMapDestinationRectangles(2, 4),
            getDungeonMapDestinationRectangles(1, 4),
            getDungeonMapDestinationRectangles(3, 3),
            getDungeonMapDestinationRectangles(5, 3),
            getDungeonMapDestinationRectangles(6, 3),
            getDungeonMapDestinationRectangles(3, 2),
            getDungeonMapDestinationRectangles(2, 2),


        },
    };

    public static Rectangle getDungeonMapDestinationRectangles(int x, int y)
    {
        return new Rectangle((128 + (x * 8)) * 4, ((8 + (y * 8)) * 4) + baseInventoryDestRect.Height, 8 * 4, 8 * 4);
    }

    internal static Rectangle GetBaseInventoryDestRect()
    {
        return baseInventoryDestRect;
    }

    internal static Rectangle GetBaseInventorySourceRect()
    {
        return baseInventorySourceRect;
    }

    internal static Rectangle GetBaseMapDestRect()
    {
        return mapSectionDestRect;
    }

    internal static Rectangle GetBaseMapSourceRect()
    {
        return mapSectionSourceRect;
    }

    internal static Rectangle GetCompassDestRect()
    {
        return compassDestRect;
    }

    internal static Rectangle GetCompassSourceRect()
    {
        return compassSourceRect;
    }

    internal static Rectangle GetEmptyCompassDestRect()
    {
        return emptyCompassDestRect;
    }

    internal static Rectangle GetEmptyCompassSourceRect()
    {
        return emptyCompassSourceRect;
    }

    internal static Rectangle GetEmptyMapDestRect()
    {
        return emptyMapDestRect;
    }

    internal static Rectangle GetEmptyMapSourceRect()
    {
        return emptyMapSourceRect;
    }

    internal static Rectangle GetMapDestRect()
    {
        return mapDestRect;
    }

    internal static Rectangle GetMapRoomRectDest(int v, int i)
    {
        return inventoryDungeonMapDestinationRects[v][i];
    }

    internal static Rectangle GetMapRoomRectSource(int v, int i)
    {
        return inventoryDungeonMapSourceRects[v][i];
    }

    internal static Rectangle GetMapSourceRect()
    {
        return mapSourceRect;
    }
}
