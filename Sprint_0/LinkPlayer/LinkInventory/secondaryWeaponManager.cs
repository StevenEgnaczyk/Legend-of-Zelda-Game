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
        public ISecondaryWeapon secondaryWeapon{ get; set; }

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

        public void AddSecondaryWeapon(secondaryWeapons weapon)
        {
            if (secondaryWeaponList.Count == 0)
            {
                secondaryWeapon = getSecondaryWeaponType(weapon);
            }
            secondaryWeaponList.Add(weapon);

        }

        public void UseBoomerang()
        {
            if (!usingSecondaryWeapon)
            {
                usingSecondaryWeapon = true;
            }

        }

        public void UseBow()
        {
            if (!usingSecondaryWeapon)
            {
                usingSecondaryWeapon = true;
            }

        }

        public void UseBomb()
        {
            if (!usingSecondaryWeapon)
            {
                usingSecondaryWeapon = true;
            }

        }

        public void UseFire()
        {
            if (!usingSecondaryWeapon)
            {
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

        public ISecondaryWeapon getSecondaryWeaponType(secondaryWeapons secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                secondaryWeaponManager.secondaryWeapons.Fire => new Fire(link),
                secondaryWeaponManager.secondaryWeapons.Bow => new Bow(link),
                secondaryWeaponManager.secondaryWeapons.Bomb => new Bomb(link),
                secondaryWeaponManager.secondaryWeapons.Boomerang => new Boomerang(link),
                _ => null
            };
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

        public ISecondaryWeapon getSecondaryWeapon()
        {
            return secondaryWeapon;
        }

        public void UseSecondaryWeapon()
        {
            if (!usingSecondaryWeapon)
            {
                secondaryWeapon.Attack();
                usingSecondaryWeapon = true;
            }
        }
    }
}
