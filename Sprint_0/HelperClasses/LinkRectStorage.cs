using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LinkRectStorage
{
    private static List<Rectangle> damagedLinkSprites = new List<Rectangle>()
    {
        new Rectangle(214, 11, 13, 16),
        new Rectangle(231, 11, 14, 16)
    };

    private static List<Rectangle> downWoodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 47, 16, 15),
        new Rectangle(18, 47, 16, 27),
        new Rectangle(35, 47, 15, 23),
        new Rectangle(53, 47, 13, 19)
    };

    private static List<Rectangle> downWhiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 47, 16, 15),
        new Rectangle(111, 47, 16, 27),
        new Rectangle(128, 47, 15, 23),
        new Rectangle(146, 47, 13, 19)
    };

    private static List<Rectangle> downMovingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(1, 11, 16, 16),
        new Rectangle(19, 11, 16, 16)
    };

    private static List<Rectangle> downAttackingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15),
        new Rectangle(94, 47, 16, 15)
    };

    private static List<Rectangle> leftWoodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(354, 206, 15, 15),
        new Rectangle(325, 206, 27, 15),
        new Rectangle(301, 206, 23, 15),
        new Rectangle(281, 205, 19, 16)

    };

    private static List<Rectangle> leftWhiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(353, 223, 15, 15),
        new Rectangle(280, 223, 19, 16),
        new Rectangle(302, 223, 21, 15),
        new Rectangle(325, 223, 26, 15)

    };

    private static List<Rectangle> leftMovingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(160, 11, 15, 16),
        new Rectangle(176, 11, 15, 16)
    };

    private static List<Rectangle> leftAttackingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(354, 206, 16, 15),
        new Rectangle(354, 206, 16, 15),
        new Rectangle(354, 206, 16, 15),
        new Rectangle(354, 206, 16, 15)
    };

    private static List<Rectangle> rightWoodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 78, 15, 15),
        new Rectangle(70, 77, 19, 16),
        new Rectangle(46, 78, 23, 15),
        new Rectangle(18, 78, 27, 15)
    };

    private static List<Rectangle> rightWhiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 78, 15, 15),
        new Rectangle(163, 77, 19, 16),
        new Rectangle(139, 78, 21, 15),
        new Rectangle(111, 78, 26, 15)
    };

    private static List<Rectangle> rightMovingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(35, 11, 16, 16),
        new Rectangle(52, 11, 15, 16)
    };

    private static List<Rectangle> rightAttackingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(124, 12, 15, 15),
        new Rectangle(124, 12, 15, 15),
        new Rectangle(124, 12, 15, 15),
        new Rectangle(124, 12, 15, 15)
    };

    private static List<Rectangle> upWoodenSwordSprites = new List<Rectangle>()
    {
        new Rectangle(1, 109, 16, 16),
        new Rectangle(54, 106, 12, 19),
        new Rectangle(37, 100, 12, 25),
        new Rectangle(18, 97, 16, 28),

    };

    private static List<Rectangle> upWhiteSwordSprites = new List<Rectangle>()
    {
        new Rectangle(94, 109, 16, 16),
        new Rectangle(147, 106, 12, 19),
        new Rectangle(130, 101, 12, 24),
        new Rectangle(111, 96, 16, 29),

    };

    private static List<Rectangle> upMovingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(71, 11, 16, 16),
        new Rectangle(88, 11, 16, 16)
    };

    private static List<Rectangle> upAttackingLinkSprites = new List<Rectangle>()
    {
        new Rectangle(141, 11, 16, 16),
        new Rectangle(141, 11, 16, 16),
        new Rectangle(141, 11, 16, 16),
        new Rectangle(141, 11, 16, 16)
    };


    public static Rectangle getDamagedLinkSprites(int index)
    {
        return damagedLinkSprites[index];

    }

    public static Rectangle getDownWoodenLinkSprites(int index)
    {
        return downWoodenSwordSprites[index];

    }

    public static Rectangle getDownWhiteLinkSprites(int index)
    {
        return downWhiteSwordSprites[index];

    }

    public static Rectangle getDownMovingLink(int index)
    {
        return downMovingLinkSprites[index];

    }

    public static Rectangle getDownAttackingLink(int index)
    {
        return downAttackingLinkSprites[index];

    }

    public static Rectangle getLeftWoodenLinkSprites(int index)
    {
        return leftWoodenSwordSprites[index];

    }

    public static Rectangle getLeftWhiteLinkSprites(int index)
    {
        return leftWhiteSwordSprites[index];

    }

    public static Rectangle getLeftMovingLink(int index)
    {
        return leftMovingLinkSprites[index];

    }

    public static Rectangle getLeftAttackingLink(int index)
    {
        return leftAttackingLinkSprites[index];

    }

    public static Rectangle getRightWoodenLinkSprites(int index)
    {
        return rightWoodenSwordSprites[index];

    }

    public static Rectangle getRightWhiteLinkSprites(int index)
    {
        return rightWhiteSwordSprites[index];

    }

    public static Rectangle getRightMovingLink(int index)
    {
        return rightMovingLinkSprites[index];

    }

    public static Rectangle getRightAttackingLink(int index)
    {
        return rightAttackingLinkSprites[index];

    }

    public static Rectangle getUpWoodenLinkSprites(int index)
    {
        return upWoodenSwordSprites[index];

    }

    public static Rectangle getUpWhiteLinkSprites(int index)
    {
        return upWhiteSwordSprites[index];

    }

    public static Rectangle getUpMovingLink(int index)
    {
        return upMovingLinkSprites[index];

    }

    public static Rectangle getUpAttackingLink(int index)
    {
        return upAttackingLinkSprites[index];

    }

}
