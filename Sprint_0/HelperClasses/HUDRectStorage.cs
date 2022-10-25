using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HUDRectStorage
{
    private static Rectangle basicHUD = new Rectangle(258, 11, 256, 56);
     
    public static Rectangle getBasicHUD()
    {
        return basicHUD;
    }

    internal static Rectangle getMapIcon()
    {
        throw new NotImplementedException();
    }

    internal static Rectangle getMapLocation(int currentRoom)
    {
        throw new NotImplementedException();
    }
}
