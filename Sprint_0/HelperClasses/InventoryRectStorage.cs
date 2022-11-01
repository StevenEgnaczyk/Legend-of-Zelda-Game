using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class InventoryRectStorage
{
    private static Rectangle baseInventoryDestRect = new Rectangle(0 * 4, 0 * 4, 256 * 4, 88 * 4);
    private static Rectangle baseInventorySourceRect = new Rectangle(1, 11, 256, 88);

    private static Rectangle mapSectionDestRect = new Rectangle(0, baseInventoryDestRect.Height, 256 * 4, 88 * 4);
    private static Rectangle mapSectionSourceRect = new Rectangle(258, 112, 256, 88);

    private static Rectangle emptyCompassSourceRect = new Rectangle(490, 18, 15, 16);
    private static Rectangle emptyCompassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle compassSourceRect = new Rectangle(612, 156, 15, 16);
    private static Rectangle compassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle mapSourceRect = new Rectangle(601, 156, 8, 16);
    private static Rectangle mapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);

    private static Rectangle emptyMapSourceRect = new Rectangle(259, 113, 8, 16);
    private static Rectangle emptyMapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);


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

    internal static Rectangle GetMapSourceRect()
    {
        return mapSourceRect;
    }
}
