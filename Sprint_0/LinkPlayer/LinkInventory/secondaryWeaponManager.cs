using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class secondaryWeaponManager
    {
        public IWeapon secondaryWeapon{ get; set; }
        public List<IWeapon> secondaryWeaponList{ get; set; }

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;

        public bool usingSecondaryWeapon = false;

        private Link link;

        public secondaryWeaponManager(Link link)
        {
            this.link = link;
            secondaryWeapon = null;
        }

        public void UseBoomerang()
        {
            if (!usingSecondaryWeapon)
            {
                boomerang = new Boomerang(link);
                secondaryWeapon = boomerang;
                usingSecondaryWeapon = true;
            }

        }

        public void UseBow(string arrowType)
        {
            if (!usingSecondaryWeapon)
            {
                bow = new Bow(link, arrowType);
                secondaryWeapon = bow;
                usingSecondaryWeapon = true;
            }

        }

        public void UseBomb()
        {
            if (!usingSecondaryWeapon)
            {
                bomb = new Bomb(link);
                secondaryWeapon = bomb;
                usingSecondaryWeapon = true;
            }

        }

        public void UseFire()
        {
            if (!usingSecondaryWeapon)
            {
                fire = new Fire(link);
                secondaryWeapon = fire;
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

        internal void UseSecondaryWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
