using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class RoomTeleportationManager
{
    public static int topTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 4,
            4 => 5,
            5 => 8,
            6 => 11,
            7 => 9,
            8 => 13,
            10 => 14,
            13 => 16,
            _ => -1
        };

    }

    public static int rightTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 3,
            2 => 1,
            5 => 7,
            6 => 5,
            8 => 9,
            9 => 10,
            11 => 8,
            12 => 11,
            14 => 15,
            17 => 16,
            _ => -1
        };

    }

    public static int leftTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 2,
            3 => 1,
            5 => 6,
            7 => 5,
            8 => 11,
            9 => 8,
            10 => 9,
            11 => 12,
            15 => 14,
            16 => 17,
            _ => -1
        };
    }

    public static int bottomTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            4 => 1,
            5 => 4,
            8 => 5,
            9 => 7,
            11 => 6,
            13 => 8,
            14 => 10,
            16 => 13,
            _ => -1
        };

    }

}

