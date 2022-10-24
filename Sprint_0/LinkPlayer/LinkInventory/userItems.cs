using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class userItems
    {
        public IWeapon currentWeapon { get; set;}

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;
        public static WoodenSword woodenSword;
        public static MagicSword magicSword;

        private bool hasWeapon = false;

        public Link link;

        public userItems(Link link)
        {
            this.link = link;
        }

        public void UseBoomerang()
        {
            if (!hasWeapon)
            {
                boomerang = new Boomerang(link);
                currentWeapon = boomerang;
                hasWeapon = true;
            }

        }

        public void UseBow(string arrowType)
        {
            if (!hasWeapon)
            {
                bow = new Bow(link, arrowType);
                currentWeapon = bow;
                hasWeapon = true;
            }

        }

        public void UseBomb()
        {
            if (!hasWeapon)
            {
                bomb = new Bomb(link);
                currentWeapon = bomb;
                hasWeapon = true;
            }

        }

        public void UseFire()
        {
            if (!hasWeapon)
            {
                fire = new Fire(link);
                currentWeapon = fire;
                hasWeapon = true;
            }

        }

        public void UseWoodenSword()
        {
            if (!hasWeapon)
            {
                woodenSword = new WoodenSword(link);
                currentWeapon = woodenSword;
                hasWeapon = true;
            }
        }

        public void UseSwordBeam()
        {
            if (!hasWeapon)
            {
                magicSword = new MagicSword(link);
                currentWeapon = magicSword;
                hasWeapon = true;
            }
        }

        public void Update()
        {
            if (hasWeapon)
            {
                currentWeapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (hasWeapon)
            {
                link.state.DrawAttacker(spriteBatch);
                currentWeapon.Draw(spriteBatch);
            }
        }

        internal void stopUsingWeapon()
        {
            currentWeapon = null;
            hasWeapon = false;
        }
    }
}
