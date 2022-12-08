using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GlobalVariables
{
    //declare global veriables to remove magic numbers from other classes
    public static int HITBOX_OFFSET = 8;
    public static int LINK_STARTING_X_ENTERING_BOTTOM = 475;
    public static int LINK_STARTING_Y_ENTERING_BOTTOM = 350;
    public static int LINK_STARTING_X_ENTERING_LEFT = 125;
    public static int LINK_STARTING_Y_ENTERING_LEFT = 550;
    public static int LINK_STARTING_X_ENTERING_RIGHT = 850;
    public static int LINK_STARTING_Y_ENTERING_RIGHT = 550;
    public static int LINK_STARTING_X_ENTERING_TOP = 490;
    public static int LINK_STARTING_Y_ENTERING_TOP = 725;
    public static int LINK_STARTING_X_ENTERING_UNDERGROUND = 250;
    public static int LINK_STARTING_Y_ENTERING_UNDERGROUND = 300;
    public static int LINK_STARTING_X_ENTERING_ABOVEGROUND = 500;
    public static int LINK_STARTING_Y_ENTERING_ABOVEGROUND = 500;

    public static int GLOBAL_SPEED_MULTIPLIER = 32;

    public static int PUSH_SPEED = 5;
    public static int TILE_PUSHBACK_SPEED = 3;

    public static int ABOVEGROUND_ROOM_ID = 17;
    public static int UNDERGROUND_ROOM_ID = 18;

    public static int DOOR_FULL_WIDTH = 128;
    public static int DOOR_FULL_HEIGHT = 128;
    public static int DOOR_BOTTOM_LOCATION = 2;
    public static int DOOR_LEFT_LOCATION = 3;
    public static int DOOR_RIGHT_LOCATION = 1;
    public static int DOOR_TOP_LOCATION = 0;

    public static Single VOLUME_CHANGE = 0.01f;

    public static int TWO = 2;

    public static int BLOCK_SIZE = 64;

}
