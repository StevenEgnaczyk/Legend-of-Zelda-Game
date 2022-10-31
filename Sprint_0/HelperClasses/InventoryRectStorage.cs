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

    internal static Rectangle GetBaseInventoryDestRect()
    {
        return baseInventoryDestRect;
    }

    internal static Rectangle GetBaseInventorySourceRect()
    {
        return baseInventorySourceRect;
    }
}
