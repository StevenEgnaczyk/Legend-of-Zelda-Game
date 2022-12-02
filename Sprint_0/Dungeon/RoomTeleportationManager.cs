using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class RoomTeleportationManager
{
    //room progression for the top door
    public static int topTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 4,
            3 => 19,
            4 => 5,
            5 => 8,
            6 => 11,
            7 => 9,
            8 => 13,
            10 => 14,
            13 => 16,
            19 => 7,
            21 => 15,
            _ => -1
        };

    }

    //room progression for the right door
    public static int rightTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 3,
            2 => 1,
            4 => 19,
            5 => 7,
            6 => 5,
            8 => 9,
            9 => 10,
            10 => 21,
            11 => 8,
            12 => 11,
            14 => 15,
            17 => 16,
            20 => 2,
            22 => 17,
            _ => -1
        };

    }

    //room progression for left door
    public static int leftTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 2,
            2 => 20,
            3 => 1,
            5 => 6,
            7 => 5,
            8 => 11,
            9 => 8,
            10 => 9,
            11 => 12,
            15 => 14,
            16 => 17,
            17 => 22,
            19 => 4,
            21 => 10,
            _ => -1
        };
    }

    //room progression for bottom door
    public static int bottomTeleporter(int currentRoomNum)
    {
        return currentRoomNum switch
        {
            1 => 23,
            4 => 1,
            5 => 4,
            7 => 19,
            8 => 5,
            9 => 7,
            11 => 6,
            13 => 8,
            14 => 10,
            15 => 21,
            16 => 13,
            19 => 3,
            _ => -1
        };

    }

}

