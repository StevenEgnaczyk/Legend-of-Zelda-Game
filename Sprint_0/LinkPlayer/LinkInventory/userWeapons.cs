using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class userWeapons
    {
        public IWeapon primaryWeapon { get; set;}
        public IWeapon secondaryWeapon{ get; set; }

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;

        public WoodenSword woodenSword;
        public MagicSword magicSword;

        public bool usingWeapon = false;

        private Link link;

        public userWeapons(Link link)
        {
            this.link = link;
            woodenSword = new WoodenSword(link);
            primaryWeapon = woodenSword;
        }

        public void UseBoomerang()
        {
            if (!usingWeapon)
            {
                boomerang = new Boomerang(link);
                secondaryWeapon = boomerang;
                usingWeapon = true;
            }

        }

        public void UseBow(string arrowType)
        {
            if (!usingWeapon)
            {
                bow = new Bow(link, arrowType);
                secondaryWeapon = bow;
                usingWeapon = true;
            }

        }

        public void UseBomb()
        {
            if (!usingWeapon)
            {
                bomb = new Bomb(link);
                secondaryWeapon = bomb;
                usingWeapon = true;
            }

        }

        public void UseFire()
        {
            if (!usingWeapon)
            {
                fire = new Fire(link);
                secondaryWeapon = fire;
                usingWeapon = true;
            }

        }

        public void UseWoodenSword()
        {
            if (!usingWeapon)
            {
                woodenSword = new WoodenSword(link);
                primaryWeapon = woodenSword;
                usingWeapon = true;
            }
        }

        public void UseSwordBeam()
        {
            if (!usingWeapon)
            {
                magicSword = new MagicSword(link);
                primaryWeapon = magicSword;
                usingWeapon = true;
            }
        }

        public void Update()
        {
            if (usingWeapon)
            {
                primaryWeapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (usingWeapon)
            {
                link.state.DrawAttackingLink(spriteBatch);
                primaryWeapon.Draw(spriteBatch);
            }
        }

        internal void stopUsingWeapon()
        {
            usingWeapon = false;
        }

        public IWeapon getPrimaryWeapon()
        {
            return primaryWeapon;
        }

        public IWeapon getSecondaryWeapon()
        {
            return secondaryWeapon;
        }

        internal void UsePrimaryWeapon()
        {
            UseWoodenSword();
        }

        internal void UseSecondaryWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
