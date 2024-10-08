using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.Versioning;

public static class AudioStorage
{
    //declare public sounds
    public static Song song;
    //   public static Song suge;
    public static SoundEffect sword_Slash;
    public static SoundEffect sword_Shoot;
    public static SoundEffect arrow;
    public static SoundEffect bomb_drop;
    public static SoundEffect bomb_blow;
    public static SoundEffect enemy_hit;
    public static SoundEffect enemy_die;
    public static SoundEffect link_hurt;
    public static SoundEffect link_die;
    public static SoundEffect get_item;
    public static SoundEffect lets_go;
    public static SoundEffect lets_go2;
    public static SoundEffect golf_hit;
    public static SoundEffect adam_die;
    public static SoundEffect golf_kill;
    public static SoundEffect suge_effect;

    //construct sounds from content loader
    public static void LoadAllSounds(ContentManager content)
    {
        song = content.Load<Song>("LOZ_title");
        //        suge = content.Load<Song>("suge");
        sword_Slash = content.Load<SoundEffect>("LOZ_Sword_Slash");
        sword_Shoot = content.Load<SoundEffect>("LOZ_Sword_Shoot");
        arrow = content.Load<SoundEffect>("LOZ_Arrow_Boomerang");
        bomb_drop = content.Load<SoundEffect>("LOZ_Bomb_Drop");
        bomb_blow = content.Load<SoundEffect>("LOZ_Bomb_Blow");
        enemy_hit = content.Load<SoundEffect>("LOZ_Enemy_Hit");
        enemy_die = content.Load<SoundEffect>("LOZ_Enemy_Die");
        link_hurt = content.Load<SoundEffect>("LOZ_Link_Hurt");
        link_die = content.Load<SoundEffect>("LOZ_Link_Die");
        get_item = content.Load<SoundEffect>("LOZ_Get_Item");
        lets_go = content.Load<SoundEffect>("Lets_go");
        lets_go2 = content.Load<SoundEffect>("lets_go2");
        golf_hit = content.Load<SoundEffect>("sorry");
        golf_kill = content.Load<SoundEffect>("suck");
        adam_die = content.Load<SoundEffect>("nonono");
        suge_effect = content.Load<SoundEffect>("suge");
    }
    
    //get methods
    public static Song GetSong()
    {
        return song;
    }

    public static SoundEffect GetSwordSlash()
    {
        return sword_Slash;
    }

    public static SoundEffect GetSwordShoot()
    {
        return sword_Shoot;
    }

    public static SoundEffect GetArrow()
    {
        return arrow;
    }

    public static SoundEffect GetBombDrop()
    {
        return bomb_drop;
    }

    public static SoundEffect GetBombBlow()
    {
        return bomb_blow;
    }

    public static SoundEffect GetEnemyHit()
    {
        return enemy_hit;
    }

    public static SoundEffect GetEnemyDie()
    {
        return enemy_die;
    }

    public static SoundEffect GetLinkHurt()
    {
        return link_hurt;
    }

    public static SoundEffect GetLinkDie()
    {
        return link_die;
    }

    public static SoundEffect GetGetItem()
    {
        return get_item;
    }

    public static SoundEffect GetLetsGo()
    {
        return lets_go;
    }

    public static SoundEffect GetLetsGo2()
    {
        return lets_go2;
    }

    public static SoundEffect GetGolfHit()
    {
        return golf_hit;
    }

    public static SoundEffect GetGolfKill()
    {
        return golf_kill;
    }

    public static SoundEffect GetAdamDie()
    {
        return adam_die;
    }

    public static SoundEffect GetSugeEffect()
    {
        return suge_effect;
    }
}