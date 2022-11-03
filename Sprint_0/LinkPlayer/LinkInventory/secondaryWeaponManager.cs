using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class secondaryWeaponManager
    {
        public IWeapon secondaryWeapon{ get; set; }

        public enum secondaryWeapons
        {
            Boomerang,
            Bow,
            Bomb,
            Fire
        }

        public List<secondaryWeapons> secondaryWeaponList{ get; set; }

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;

        public bool usingSecondaryWeapon = false;

        private Link link;

        public secondaryWeaponManager(Link link)
        {
            this.link = link;
            secondaryWeaponList = new List<secondaryWeapons>();
            secondaryWeapon = null;
        }

        public void UseBoomerang()
        {
            if (!usingSecondaryWeapon)
            {
                boomerang = new Boomerang(link);
                usingSecondaryWeapon = true;
            }

        }

        public void UseBow()
        {
            if (!usingSecondaryWeapon)
            {
                bow = new Bow(link);
                usingSecondaryWeapon = true;
            }

        }

        public void UseBomb()
        {
            if (!usingSecondaryWeapon)
            {
                bomb = new Bomb(link);
                usingSecondaryWeapon = true;
            }

        }

        public void UseFire()
        {
            if (!usingSecondaryWeapon)
            {
                fire = new Fire(link);
                usingSecondaryWeapon = true;
            }

        }

        public void Update()
        {
            if (usingSecondaryWeapon)
            {
                secondaryWeapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (usingSecondaryWeapon)
            {
                link.state.DrawAttackingLink(spriteBatch);
                secondaryWeapon.Draw(spriteBatch);
            }
        }

        internal void stopUsingWeapon()
        {
            usingSecondaryWeapon = false;
        }

        public IWeapon getSecondaryWeapon()
        {
            return secondaryWeapon;
        }

        public void UseSecondaryWeapon()
        {
            switch(secondaryWeapon)
            {
                case Bow:
                    UseBow();
                    break;
                case Fire:
                    UseFire();
                    break;
                case Boomerang:
                    UseBoomerang();
                    break;
                case Bomb:
                    UseBomb();
                    break;
                default:
                    break;

            }
        }
    }
}
