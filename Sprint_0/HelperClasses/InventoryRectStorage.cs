using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using Sprint_0.LinkPlayer.LinkInventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint_0.LinkPlayer.LinkInventory.secondaryWeaponManager;

public static class InventoryRectStorage
{
    //declare rectangles and rectangle lists for all inventory uses
    private static Rectangle baseInventoryDestRect = new Rectangle(0 * 4, 0 * 4, 256 * 4, 89 * 4);
    private static Rectangle baseInventorySourceRect = new Rectangle(1, 11, 256, 88);

    private static Rectangle mapSectionDestRect = new Rectangle(0, baseInventoryDestRect.Height, 256 * 4, 89 * 4);
    private static Rectangle mapSectionSourceRect = new Rectangle(258, 112, 256, 88);

    private static Rectangle emptyCompassSourceRect = new Rectangle(488, 118, 15, 16);
    private static Rectangle emptyCompassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle compassSourceRect = new Rectangle(612, 156, 15, 16);
    private static Rectangle compassDestRect = new Rectangle(44 * 4, baseInventoryDestRect.Height + (64 * 4), 15 * 4, 16 * 4);

    private static Rectangle mapSourceRect = new Rectangle(601, 156, 8, 16);
    private static Rectangle mapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);

    private static Rectangle emptyMapSourceRect = new Rectangle(488, 118, 8, 16);
    private static Rectangle emptyMapDestRect = new Rectangle(48 * 4, baseInventoryDestRect.Height + (24 * 4), 8 * 4, 16 * 4);

    private static Rectangle secondaryWeaponDestRect = new Rectangle(68 * 4, 48 * 4, 8 * 4, 16 * 4);

    private static Rectangle weaponBoxSource = new Rectangle(519, 137, 16, 16);
    private static Rectangle weaponBoxDest = new Rectangle(68 * 4, 48 * 4, 8 * 4, 16 * 4);

    private static List<Rectangle> dungeonMapInformationSourceRects = new List<Rectangle>
    {
        new Rectangle(519, 107, 8, 8),
        new Rectangle(527, 107, 8, 8),
        new Rectangle(536, 107, 8, 8),
        new Rectangle(546, 107, 8, 8),
        new Rectangle(556, 107, 8, 8),
        new Rectangle(564, 107, 8, 8),
        new Rectangle(573, 107, 8, 8),
        new Rectangle(583, 107, 8, 8),
        new Rectangle(593, 107, 8, 8),
        new Rectangle(602, 107, 8, 8),
        new Rectangle(611, 107, 8, 8),
        new Rectangle(621, 107, 8, 8),
        new Rectangle(631, 107, 8, 8),
        new Rectangle(640, 107, 8, 8),
        new Rectangle(649, 107, 8, 8),
        new Rectangle(659, 107, 8, 8)
    };

    private static Rectangle HUDMapSourceRect = new Rectangle(693, 103, 7, 3);


    private static List<List<Rectangle>> inventoryDungeonMapSourceRects = new List<List<Rectangle>>
    {
        //Dungeon 1 Rectangles
        new List<Rectangle>
        {
            //Room 1
            dungeonMapInformationSourceRects[15],

            //Room 2
            dungeonMapInformationSourceRects[3],

            //Room 3
            dungeonMapInformationSourceRects[10],

            //Room 4
            dungeonMapInformationSourceRects[13],

            //Room 5
            dungeonMapInformationSourceRects[15],

            //Room 6
            dungeonMapInformationSourceRects[9],

            //Room 7
            dungeonMapInformationSourceRects[10],

            //Room 8
            dungeonMapInformationSourceRects[15],

            //Room 9
            dungeonMapInformationSourceRects[7],

            //Room 10
            dungeonMapInformationSourceRects[11],

            //Room 11
            dungeonMapInformationSourceRects[7],

            //Room 12
            dungeonMapInformationSourceRects[1],

            //Room 13
            dungeonMapInformationSourceRects[12],

            //Room 14
            dungeonMapInformationSourceRects[5],

            //Room 15
            dungeonMapInformationSourceRects[6],

            //Room 16
            dungeonMapInformationSourceRects[6],

            //Room 17
            dungeonMapInformationSourceRects[3],

            //Room 18
            dungeonMapInformationSourceRects[0],

            //Room 19
            dungeonMapInformationSourceRects[14],

            //Room 20
            dungeonMapInformationSourceRects[1],

            //Room 21
            dungeonMapInformationSourceRects[10],

            //Room 22
            dungeonMapInformationSourceRects[1],

            //Room 23
            dungeonMapInformationSourceRects[0],
        },
    };

    private static List<List<Rectangle>> inventoryDungeonMapDestinationRects = new List<List<Rectangle>>
    {
        //Dungeon 1 Rectangles
        new List<Rectangle>
        {
            //Room 0
            getDungeonMapDestinationRectangles(3, 7),

            //Room 1
            getDungeonMapDestinationRectangles(2, 7),

            //Room 2
            getDungeonMapDestinationRectangles(4, 7),

            //Room 3
            getDungeonMapDestinationRectangles(3, 6),

            //Room 4
            getDungeonMapDestinationRectangles(3, 5),

            //Room 5
            getDungeonMapDestinationRectangles(2, 5),

            //Room 6
            getDungeonMapDestinationRectangles(4, 5),

            //Room 7
            getDungeonMapDestinationRectangles(3, 4),

            //Room 8
            getDungeonMapDestinationRectangles(4, 4),

            //Room 9
            getDungeonMapDestinationRectangles(5, 4),

            //Room 10
            getDungeonMapDestinationRectangles(2, 4),

            //Room 11
            getDungeonMapDestinationRectangles(1, 4),

            //Room 12
            getDungeonMapDestinationRectangles(3, 3),

            //Room 13
            getDungeonMapDestinationRectangles(5, 3),

            //Room 14
            getDungeonMapDestinationRectangles(6, 3),

            //Room 15
            getDungeonMapDestinationRectangles(3, 2),

            //Room 16
            getDungeonMapDestinationRectangles(2, 2),

            //Room 17
            getDungeonMapDestinationRectangles(2, 3),

            //Room 18
            getDungeonMapDestinationRectangles(4, 6),

            //Room 19
            getDungeonMapDestinationRectangles(1, 7),

            //Room 20
            getDungeonMapDestinationRectangles(6, 4),

            //Room 21
            getDungeonMapDestinationRectangles(1, 2),

            //Room 22
            getDungeonMapDestinationRectangles(3, 8),

            //Room 23 
            getDungeonMapDestinationRectangles(2, 3),


        },
    };

    private static List<List<Rectangle>> HUDDungeonMapDestinationRects = new List<List<Rectangle>>
    {
        //Dungeon 1 Rectangles
        new List<Rectangle>
        {
            //Room 0
            getHUDMapDestinationRectangles(3, 7),

            //Room 1
            getHUDMapDestinationRectangles(2, 7),

            //Room 2
            getHUDMapDestinationRectangles(4, 7),

            //Room 3
            getHUDMapDestinationRectangles(3, 6),

            //Room 4
            getHUDMapDestinationRectangles(3, 5),

            //Room 5
            getHUDMapDestinationRectangles(2, 5),

            //Room 6
            getHUDMapDestinationRectangles(4, 5),

            //Room 7
            getHUDMapDestinationRectangles(3, 4),

            //Room 8
            getHUDMapDestinationRectangles(4, 4),

            //Room 9
            getHUDMapDestinationRectangles(5, 4),

            //Room 10
            getHUDMapDestinationRectangles(2, 4),

            //Room 11
            getHUDMapDestinationRectangles(1, 4),

            //Room 12
            getHUDMapDestinationRectangles(3, 3),

            //Room 13
            getHUDMapDestinationRectangles(5, 3),

            //Room 14
            getHUDMapDestinationRectangles(6, 3),

            //Room 15
            getHUDMapDestinationRectangles(3, 2),

            //Room 16
            getHUDMapDestinationRectangles(2, 2),

            //Room 17
            getHUDMapDestinationRectangles(2, 3),

            //Room 18
            getHUDMapDestinationRectangles(4, 6),

            //Room 19
            getHUDMapDestinationRectangles(1, 7),

            //Room 20
            getHUDMapDestinationRectangles(6, 4),

            //Room 21
            getHUDMapDestinationRectangles(1, 2),

            //Room 22
            getHUDMapDestinationRectangles(3, 8),

            //Room 23 
            getHUDMapDestinationRectangles(2, 3),


        },
    };



    private static List<Rectangle> secondaryWeaponDestinationRectangles = new List<Rectangle>()
    {
        new Rectangle((129 * 4), (47 * 4), (16 * 4), (16 * 4)),
        new Rectangle((153 * 4), (47 * 4), (16 * 4), (16 * 4)),
        new Rectangle((177 * 4), (47 * 4), (16 * 4), (16 * 4)),
        new Rectangle((201 * 4), (47 * 4), (16 * 4), (16 * 4)),
    };
    
    //get methods for inventory rectangles
    public static Rectangle getDungeonMapDestinationRectangles(int x, int y)
    {
        return new Rectangle((128 + (x * 8)) * 4, ((8 + (y * 8)) * 4) + ( baseInventoryDestRect.Height - 32), 8 * 4, 8 * 4);
    }

    public static Rectangle getHUDMapDestinationRectangles(int x, int y)
    {
        return new Rectangle(((x * 10) * 4) + 48, ((y * 6) * 4) + 1, 10 * 4, 6 * 4);
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

    internal static Rectangle GetInventoryMapRoomRectDest(int v, int i)
    {
        return inventoryDungeonMapDestinationRects[v][i];
    }

    internal static Rectangle GetInventoryMapRoomRectSource(int v, int i)
    {
        return inventoryDungeonMapSourceRects[v][i];
    }

    internal static Rectangle GetMapSourceRect()
    {
        return mapSourceRect;
    }

    internal static Rectangle GetSecondaryWeaponDestRect(secondaryWeaponManager.secondaryWeapons secondaryWeapon)
    {
        return secondaryWeapon switch
        {
            secondaryWeaponManager.secondaryWeapons.Fire => new Rectangle(204 * 4, 48 * 4, 8 * 4, 16 * 4),
            secondaryWeaponManager.secondaryWeapons.Bow => new Rectangle(176 * 4, 48 * 4, 16 * 4, 16 * 4),
            secondaryWeaponManager.secondaryWeapons.Bomb => new Rectangle(156 * 4, 48 * 4, 8 * 4, 16 * 4),
            secondaryWeaponManager.secondaryWeapons.Boomerang => new Rectangle(132 * 4, 48 * 4, 8 * 4, 16 * 4),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetSecondaryWeaponDestRect(ISecondaryWeapon secondaryWeapon)
    {
        return secondaryWeapon.GetType().ToString().Split(".")[3].ToString() switch
        {
            "Fire" => new Rectangle(204 * 4, 48 * 4, 8 * 4, 16 * 4),
            "Bow" => new Rectangle(176 * 4, 48 * 4, 16 * 4, 16 * 4),
            "Bomb" => new Rectangle(156 * 4, 48 * 4, 8 * 4, 16 * 4),
            "Boomerang" => new Rectangle(132 * 4, 48 * 4, 8 * 4, 16 * 4),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetSecondaryWeaponSourceRect(secondaryWeaponManager.secondaryWeapons secondaryWeapon)
    {
        return secondaryWeapon switch
        {
            secondaryWeaponManager.secondaryWeapons.Fire => new Rectangle(653, 137, 8, 16),
            secondaryWeaponManager.secondaryWeapons.Bow => new Rectangle(625, 137, 16, 16),
            secondaryWeaponManager.secondaryWeapons.Bomb => new Rectangle(604, 137, 8, 16),
            secondaryWeaponManager.secondaryWeapons.Boomerang => new Rectangle(584, 137, 8, 16),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetSecondaryWeaponSourceRect(ISecondaryWeapon secondaryWeapon)
    {
        return secondaryWeapon.GetType().ToString().Split(".")[3].ToString() switch
        {
            "Fire" => new Rectangle(653, 137, 8, 16),
            "Bow" => new Rectangle(625, 137, 16, 16),
            "Bomb" => new Rectangle(604, 137, 8, 16),
            "Boomerang" => new Rectangle(584, 137, 8, 16),
            _ => new Rectangle(0, 0, 16, 16),
        };
    }

    internal static Rectangle GetCurrentSecondaryWeaponDestinationRect()
    {
        return secondaryWeaponDestRect;
    }

    internal static Rectangle GetWeaponBoxSource()
    {
        return weaponBoxSource;
    }

    internal static Rectangle GetSecondaryWeaponDestRect(int index)
    {
        return secondaryWeaponDestinationRectangles[index];
    }

    internal static Rectangle GetHUDMapRoomRectDest(int v, int i)
    {
        return HUDDungeonMapDestinationRects[v][i];
    }

    internal static Rectangle GetHUDMapRoomRectSource()
    {
        return HUDMapSourceRect;
    }
}
