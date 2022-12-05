﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class OutOfBoundsTest
{
    //buffer class for animation
    public static bool itemOutOfBounds(int objectX, int objectY)
    {
        if (objectX < 128 || objectX > (1024 - 128))
        {
            return true;
        }

        if (objectY > (1024 - 128) || objectY < RoomRectStorage.HUDHeight)
        {
            return true;
        }

        return false;
    }

    public static bool itemOutOfBounds(float objectX, float objectY)
    {
        if (objectX < 128 || objectX > (1024 - 128))
        {
            return true;
        }

        if (objectY > (1024 - 128) || objectY < RoomRectStorage.HUDHeight)
        {
            return true;
        }

        return false;
    }
}
