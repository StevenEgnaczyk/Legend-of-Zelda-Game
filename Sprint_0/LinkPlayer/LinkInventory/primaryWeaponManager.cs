using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
        public IPrimaryWeapon primaryWeapon { get; set;}

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
                AudioStorage.GetSwordSlash().Play();
            }
        }

        public void UseSwordBeam()
        {
            if (!usingPrimaryWeapon)
            {
                magicSword = new MagicSword(link);
                primaryWeapon = magicSword;
                usingPrimaryWeapon = true;
                AudioStorage.GetSwordShoot().Play();
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

        public IPrimaryWeapon getPrimaryWeapon()
        {
            return primaryWeapon;
        }

        internal void UsePrimaryWeapon()
        {
            if (!usingPrimaryWeapon && !link.inventory.secondaryWeaponManager.usingSecondaryWeapon)
            {
                UseWoodenSword();
            }
        }

        internal Rectangle getRect()
        {
            return new Rectangle(primaryWeapon.getXPos(), primaryWeapon.getYPos(), primaryWeapon.getWidth(), primaryWeapon.getHeight());
        }
    }
}
