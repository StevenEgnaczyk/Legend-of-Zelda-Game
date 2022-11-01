using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class primaryWeaponManager
    {
        public IWeapon primaryWeapon { get; set;}

        public WoodenSword woodenSword;
        public MagicSword magicSword;

        public bool usingPrimaryWeapon = false;

        private Link link;

        public primaryWeaponManager(Link link)
        {
            this.link = link;
            woodenSword = new WoodenSword(link);
            primaryWeapon = woodenSword;
        }
        public void UseWoodenSword()
        {
            if (!usingPrimaryWeapon)
            {
                woodenSword = new WoodenSword(link);
                primaryWeapon = woodenSword;
                usingPrimaryWeapon = true;
            }
        }

        public void UseSwordBeam()
        {
            if (!usingPrimaryWeapon)
            {
                magicSword = new MagicSword(link);
                primaryWeapon = magicSword;
                usingPrimaryWeapon = true;
            }
        }

        public void Update()
        {
            if (usingPrimaryWeapon)
            {
                primaryWeapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (usingPrimaryWeapon)
            {
                link.state.DrawAttackingLink(spriteBatch);
                primaryWeapon.Draw(spriteBatch);
            }
        }

        internal void stopUsingWeapon()
        {
            usingPrimaryWeapon = false;
        }

        public IWeapon getPrimaryWeapon()
        {
            return primaryWeapon;
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
