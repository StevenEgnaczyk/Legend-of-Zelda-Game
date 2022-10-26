using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HUDRectStorage
{
    private static Rectangle basicHUD = new Rectangle(258, 11, 256, 56);
    private static Rectangle mapIcon = new Rectangle(519, 126, 4, 4);

    private static Rectangle blankIcon = new Rectangle(654, 117, 8, 8);
    private static Rectangle xIcon = new Rectangle(519, 117, 8, 8);
    private static List<Rectangle> digitSourceRectangles = new List<Rectangle>
    {
        new Rectangle(528, 117, 8, 8),
        new Rectangle(537, 117, 8, 8),
        new Rectangle(546, 117, 8, 8),
        new Rectangle(555, 117, 8, 8),
        new Rectangle(564, 117, 8, 8),
        new Rectangle(573, 117, 8, 8),
        new Rectangle(582, 117, 8, 8),
        new Rectangle(591, 117, 8, 8),
        new Rectangle(600, 117, 8, 8),
        new Rectangle(609, 117, 8, 8),
};

    private static Rectangle xRupeeIconDestination = new Rectangle(96 * 4, 16 * 4, 8 * 4, 8 * 4);
    private static Rectangle rupeeDigit1Destination = new Rectangle(104 * 4, 16 * 4, 8 * 4, 8 * 4);
    private static Rectangle rupeeDigit2Destination = new Rectangle(112 * 4, 16 * 4, 8 * 4, 8 * 4);

    private static Rectangle xKeyIconDestination = new Rectangle(96 * 4, 32 * 4, 8 * 4, 8 * 4);
    private static Rectangle keyDigit1Destination = new Rectangle(104 * 4, 32 * 4, 8 * 4, 8 * 4);
    private static Rectangle keyDigit2Destination = new Rectangle(112 * 4, 32 * 4, 8 * 4, 8 * 4);

    private static Rectangle xBombIconDestination = new Rectangle(96 * 4, 40 * 4, 8 * 4, 8 * 4);
    private static Rectangle bombDigit1Destination = new Rectangle(104 * 4, 40 * 4, 8 * 4, 8 * 4);
    private static Rectangle bombDigit2Destination = new Rectangle(112 * 4, 40 * 4, 8 * 4, 8 * 4);

    private static Rectangle primaryWeaponDestRect = new Rectangle(152 * 4, 24 * 4, 8 * 4, 16 * 4);
    private static Dictionary<String, Rectangle> primaryWeaponSourceRectangles = new Dictionary<string, Rectangle>()
    {
        {"Sprint_0.LinkPlayer.LinkInventory.WoodenSword", new Rectangle(555, 137, 8, 16) },
        {"MagicSword", new Rectangle(564, 137, 8, 16) },
    };

    private static Rectangle emptyWeaponSourceRect = new Rectangle(482, 112, 8, 16);

    public static Rectangle getBasicHUD()
    {
        return basicHUD;
    }

    internal static Rectangle getBlank()
    {
        return blankIcon;
    }

    internal static Rectangle getBombDigit1DestRect()
    {
        return bombDigit1Destination;
    }

    internal static Rectangle getBombDigit2DestRect()
    {
        return bombDigit2Destination;
    }

    internal static Rectangle getBombXDestRect()
    {
        return xBombIconDestination;
    }

    internal static Rectangle getDigit(int digit)
    {
        return digitSourceRectangles[digit];
    }

    internal static Rectangle getKeyDigit1DestRect()
    {
        return keyDigit1Destination;
    }

    internal static Rectangle getKeyDigit2DestRect()
    {
        return keyDigit2Destination;
    }

    internal static Rectangle getKeyXDestRect()
    {
        return xKeyIconDestination;
    }

    internal static Rectangle getMapIcon()
    {
        return mapIcon;
    }

    internal static Rectangle getMapLocation(int currentRoom)
    {
        return currentRoom switch
        {
            0 => new Rectangle(46 * 4, 43 * 4, 4 * 4, 4 * 4),
            1 => new Rectangle(41 * 4, 43 * 4, 4 * 4, 4 * 4),
            2 => new Rectangle(51 * 4, 43 * 4, 4 * 4, 4 * 4),
            3 => new Rectangle(46 * 4, 38 * 4, 4 * 4, 4 * 4),
            4 => new Rectangle(46 * 4, 33 * 4, 4 * 4, 4 * 4),
            5 => new Rectangle(41 * 4, 33 * 4, 4 * 4, 4 * 4),
            6 => new Rectangle(51 * 4, 33 * 4, 4 * 4, 4 * 4),
            7 => new Rectangle(46 * 4, 28 * 4, 4 * 4, 4 * 4),
            8 => new Rectangle(51 * 4, 28 * 4, 4 * 4, 4 * 4),
            9 => new Rectangle(56 * 4, 28 * 4, 4 * 4, 4 * 4),
            10 => new Rectangle(41 * 4, 28 * 4, 4 * 4, 4 * 4),
            11 => new Rectangle(36 * 4, 28 * 4, 4 * 4, 4 * 4),
            12 => new Rectangle(46 * 4, 23 * 4, 4 * 4, 4 * 4),
            13 => new Rectangle(56 * 4, 23 * 4, 4 * 4, 4 * 4),
            14 => new Rectangle(61 * 4, 23 * 4, 4 * 4, 4 * 4),
            15 => new Rectangle(46 * 4, 18 * 4, 4 * 4, 4 * 4),
            16 => new Rectangle(41 * 4, 18 * 4, 4 * 4, 4 * 4),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetPrimaryWeaponDestRect()
    {
        return primaryWeaponDestRect;
    }

    internal static Rectangle GetPrimaryWeaponSourceRect(IWeapon primaryWeapon)
    {
        if (primaryWeapon == null)
        {
            return emptyWeaponSourceRect;
        }
        return primaryWeaponSourceRectangles[primaryWeapon.ToString()];
    }

    internal static Rectangle getRupeeDigit1DestRect()
    {
        return rupeeDigit1Destination;
    }

    internal static Rectangle getRupeeDigit2DestRect()
    {
        return rupeeDigit2Destination;
    }

    internal static Rectangle getRupeeXDestRect()
    {
        return xRupeeIconDestination;
    }

    internal static Rectangle getXIcon()
    {
        return xIcon;
    }
}
