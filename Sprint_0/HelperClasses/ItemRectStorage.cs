using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ItemRectStorage
{
    private static List<Rectangle> arrowSprite = new List<Rectangle>()
    {
        new Rectangle(154, 0, 5, 16)
    };

    private static List<Rectangle> bombSprite = new List<Rectangle>()
    {
        new Rectangle(136, 0, 8, 14)
    };

    private static List<Rectangle> bowSprite = new List<Rectangle>()
    {
        new Rectangle(144, 0, 8, 16)
    };

    private static List<Rectangle> clockSprite = new List<Rectangle>()
    {
        new Rectangle(58, 0, 11, 16)
    };

    private static List<Rectangle> compassSprite = new List<Rectangle>()
    {
        new Rectangle(258, 1, 11, 12)
    };

    private static List<Rectangle> fairySprites = new List<Rectangle>()
    {
        new Rectangle(40, 0, 7, 16),
        new Rectangle(47, 0, 7, 16)

    };

    private static List<Rectangle> flameSprites = new List<Rectangle>()
    {
        new Rectangle(52,11,16,16),
        new Rectangle(68, 11, 16, 16)

    };

    private static List<Rectangle> heartContainerSprite = new List<Rectangle>()
    {
        new Rectangle(25, 1, 13, 13)
    };

    private static List<Rectangle> heartSprites = new List<Rectangle>()
    {
        new Rectangle(0, 0, 7, 8),
        new Rectangle(0, 8 ,7,8)
    };

    private static List<Rectangle> keySprite = new List<Rectangle>()
    {
        new Rectangle(240, 0, 8, 16)
    };

    private static List<Rectangle> mapSprite = new List<Rectangle>()
    {
        new Rectangle(232, 0, 8, 16)
    };

    private static List<Rectangle> rupeeSprites = new List<Rectangle>()
    {
        new Rectangle(72, 0, 8, 16),
        new Rectangle(72, 16, 8, 16)
    };

    private static List<Rectangle> woodenBoomerangSprites = new List<Rectangle>()
    {
        new Rectangle(129, 3, 5, 8),
        new Rectangle(120, 30, 8, 5),
        new Rectangle(129, 28, 5, 8),
        new Rectangle(135, 30, 8, 5)
    };

    private static Rectangle candleSprite = new Rectangle(160, 0, 8, 16);

    private static List<Rectangle> deathAnimation = new List<Rectangle>()
    {
        new Rectangle(0, 0, 15, 16),
        new Rectangle(16, 0, 15, 16),
        new Rectangle(35, 3, 9, 10),
        new Rectangle(51, 3, 9, 10)
    };

    public static Rectangle getArrowSprite()
    {
        return arrowSprite[0];

    }

    public static Rectangle getBombSprite()
    {
        return bombSprite[0];

    }

    public static Rectangle getBowSprite()
    {
        return bowSprite[0];

    }

    public static Rectangle getClockSprite()
    {
        return clockSprite[0];

    }

    public static Rectangle getCompassSprite()
    {
        return compassSprite[0];

    }

    public static Rectangle getFairySprites(int index)
    {
        return fairySprites[index];

    }

    public static Rectangle getFlameSprites(int index)
    {
        return flameSprites[index];

    }

    public static Rectangle getHeartContainerSprite()
    {
        return heartContainerSprite[0];

    }

    public static Rectangle getHeartSprites(int index)
    {
        return heartSprites[index];

    }

    public static Rectangle getKeySprite()
    {
        return keySprite[0];

    }

    public static Rectangle getMapSprite()
    {
        return mapSprite[0];

    }

    public static Rectangle getRupeeSprites(int index)
    {
        return rupeeSprites[index];

    }

    public static Rectangle getWoodenBoomerangSprites(int index)
    {
        return woodenBoomerangSprites[index];

    }

    internal static Rectangle getCandleSprite()
    {
        return candleSprite;
    }
    
    public static Rectangle getDeathAnimation(int index)
    {
        return deathAnimation[index];
    }
}
