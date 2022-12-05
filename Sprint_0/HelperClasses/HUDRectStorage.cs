using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HUDRectStorage
{
    //declare rectangles and rectangle lists for all HUD uses
    private static Rectangle basicHUD = new Rectangle(258, 11, 256, 56);
    private static List<Rectangle> mapIcons = new List<Rectangle>
    {
        new Rectangle(520, 127, 4, 4),
        new Rectangle(536, 126, 4, 4),
        new Rectangle(528, 127, 4, 4),
    };

    private static Rectangle levelTextSourceRect = new Rectangle(584, 1, 48, 7);
    private static Rectangle levelTextDestRect = new Rectangle(16 * 4, 7 * 4, 48 * 4, 7 * 4);
    private static Rectangle levelNumDestRect = new Rectangle(64 * 4, 7 * 4, 8 * 4, 8 * 4);
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

    private static Rectangle xDaTokenIconDestination = new Rectangle(96 * 4, 4 * 4, 8 * 4, 8 * 4);
    private static Rectangle daTokenDigit1Destination = new Rectangle(104 * 4, 4 * 4, 8 * 4, 8 * 4);
    private static Rectangle daTokenDigit2Destination = new Rectangle(112 * 4, 4 * 4, 8 * 4, 8 * 4);

    private static Rectangle primaryWeaponDestRect = new Rectangle(152 * 4, 24 * 4, 8 * 4, 16 * 4);
    private static Dictionary<String, Rectangle> primaryWeaponSourceRectangles = new Dictionary<string, Rectangle>()
    {
        {"WoodenSword", new Rectangle(555, 137, 8, 16) },
        {"MagicSword", new Rectangle(564, 137, 8, 16) },
    };

    private static Rectangle secondaryWeaponDestRect = new Rectangle(128 * 4, 24 * 4, 8 * 4, 16 * 4);
    private static Dictionary<String, Rectangle> secondaryWeaponSourceRectangles = new Dictionary<string, Rectangle>()
    {
        {"Bow", new Rectangle(633, 137, 8, 16) },
        {"Boomerang", new Rectangle(583, 137, 8, 16) },
        {"Bomb", new Rectangle(604, 137, 8, 16) },
        {"Fire", new Rectangle(653, 137, 8, 16) },
    };

    private static Rectangle fullHeartSourceRect = new Rectangle(645, 117, 8, 8);
    private static Rectangle halfHeartSourceRect = new Rectangle(636, 117, 8, 8);
    private static Rectangle emptyHeartSourceRect = new Rectangle(627, 117, 8, 8);

    private static List<Rectangle> heartDestRects = new List<Rectangle>
    {
        new Rectangle(176 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(184 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(192 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(200 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(208 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(216 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(224 * 4, 40 * 4, 8 * 4, 8 * 4),
        new Rectangle(232 * 4, 40 * 4, 8 * 4, 8 * 4),
    };

    private static Rectangle emptyWeaponSourceRect = new Rectangle(484, 112, 8, 16);

    //get methods for the HUD rectangles
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

    internal static Rectangle getDaTokensDigit1DestRect()
    {
        return daTokenDigit1Destination;
    }

    internal static Rectangle getDaTokensDigit2DestRect()
    {
        return daTokenDigit2Destination;
    }

    internal static Rectangle getDaTokensXDestRect()
    {
        return xDaTokenIconDestination;
    }

    internal static Rectangle getDigit(int digit)
    {
        return digitSourceRectangles[digit];
    }

    internal static Rectangle GetEmptyHeartSourceRect()
    {
        return emptyHeartSourceRect;
    }

    internal static Rectangle GetFullHeartSourceRect()
    {
        return fullHeartSourceRect;
    }

    internal static Rectangle GetHalfHeartSourceRect()
    {
        return halfHeartSourceRect;
    }

    internal static Rectangle GetHeartDestRect(int heartIndex)
    {
        return heartDestRects[heartIndex];
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

    internal static Rectangle GetLevelNumDestRect()
    {
        return levelNumDestRect;
    }

    internal static Rectangle GetLevelTextDestRect()
    {
        return levelTextDestRect;
    }

    internal static Rectangle GetLevelTextSourceRect()
    {
        return levelTextSourceRect;
    }

    internal static Rectangle getMapIcon(int currentRoom)
    {
        return (currentRoom) switch
        {
            18 => mapIcons[1],
            23 => mapIcons[2],
            _ => mapIcons[0],
        };
    }

    internal static Rectangle getMapLocation(int currentRoom)
    {
        return (currentRoom) switch
        {
            1 => new Rectangle(46 * 4, 43 * 4, 4 * 4, 4 * 4),
            2 => new Rectangle(41 * 4, 43 * 4, 4 * 4, 4 * 4),
            3 => new Rectangle(51 * 4, 43 * 4, 4 * 4, 4 * 4),
            4 => new Rectangle(46 * 4, 38 * 4, 4 * 4, 4 * 4),
            5 => new Rectangle(46 * 4, 33 * 4, 4 * 4, 4 * 4),
            6 => new Rectangle(41 * 4, 33 * 4, 4 * 4, 4 * 4),
            7 => new Rectangle(51 * 4, 33 * 4, 4 * 4, 4 * 4),
            8 => new Rectangle(46 * 4, 28 * 4, 4 * 4, 4 * 4),
            9 => new Rectangle(51 * 4, 28 * 4, 4 * 4, 4 * 4),
            10 => new Rectangle(56 * 4, 28 * 4, 4 * 4, 4 * 4),
            11 => new Rectangle(41 * 4, 28 * 4, 4 * 4, 4 * 4),
            12 => new Rectangle(36 * 4, 28 * 4, 4 * 4, 4 * 4),
            13 => new Rectangle(46 * 4, 23 * 4, 4 * 4, 4 * 4),
            14 => new Rectangle(56 * 4, 23 * 4, 4 * 4, 4 * 4),
            15 => new Rectangle(61 * 4, 23 * 4, 4 * 4, 4 * 4),
            16 => new Rectangle(46 * 4, 18 * 4, 4 * 4, 4 * 4),
            17 => new Rectangle(41 * 4, 18 * 4, 4 * 4, 4 * 4),
            18 => new Rectangle(41 * 4, 18 * 4, 4 * 4, 4 * 4),
            19 => new Rectangle(51 * 4, 38 * 4, 4 * 4, 4 * 4),
            20 => new Rectangle(36 * 4, 43 * 4, 4 * 4, 4 * 4),
            21 => new Rectangle(61 * 4, 28 * 4, 4 * 4, 4 * 4),
            22 => new Rectangle(36 * 4, 18 * 4, 4 * 4, 4 * 4),
            23 => new Rectangle(46 * 4, 48 * 4, 4 * 4, 4 * 4),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetPrimaryWeaponDestRect()
    {
        return primaryWeaponDestRect;
    }

    internal static Rectangle GetPrimaryWeaponSourceRect(IPrimaryWeapon primaryWeapon)
    {
        if (primaryWeapon == null)
        {
            return emptyWeaponSourceRect;
        }
        string[] primaryWeaponInfo = primaryWeapon.GetType().ToString().Split(".");
        return primaryWeaponSourceRectangles[primaryWeaponInfo[3].ToString()];
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

    internal static Rectangle GetSecondaryWeaponDestRect()
    {
        return secondaryWeaponDestRect;
    }

    internal static Rectangle GetSecondaryWeaponSourceRect(ISecondaryWeapon secondaryWeapon)
    {
        if (secondaryWeapon == null)
        {
            return emptyWeaponSourceRect;
        }
        else
        {
            string[] secondaryWeaponInfo = secondaryWeapon.GetType().ToString().Split(".");
            return secondaryWeaponSourceRectangles[secondaryWeaponInfo[3].ToString()];
        }
    }

    internal static Rectangle getXIcon()
    {
        return xIcon;
    }
}
