using Microsoft.Xna.Framework;
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
                secondaryWeapon = getSecondaryWeaponTypeByEnum(weapon);
            }
            secondaryWeaponList.Add(weapon);
            link.inventory.inventoryManager.setSelectedSecondaryWeaponIndex(getSecondaryWeaponIndexByEnum(weapon));

        }

        public void Update()
        {
            if (usingSecondaryWeapon)
            {
                secondaryWeapon.Update();
            }
        }

        public ISecondaryWeapon getSecondaryWeaponTypeByEnum(secondaryWeapons secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                secondaryWeaponManager.secondaryWeapons.Fire => new Fire(link),
                secondaryWeaponManager.secondaryWeapons.Bow => new Bow(link),
                secondaryWeaponManager.secondaryWeapons.Bomb => new Bomb(link),
                secondaryWeaponManager.secondaryWeapons.Boomerang => new Boomerang(link),
            };
        }

        public ISecondaryWeapon getSecondaryWeaponTypeByInt(int secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                0 => new Boomerang(link),
                1 => new Bomb(link),
                2 => new Bow(link),
                3 => new Fire(link),
            };
        }

        public int getSecondaryWeaponIndexByEnum(secondaryWeapons weapon)
        {
            return weapon switch
            {
                secondaryWeapons.Boomerang => 0,
                secondaryWeapons.Bomb => 1,
                secondaryWeapons.Bow => 2,
                secondaryWeapons.Fire => 3,
            };
        }

        internal bool HasSelectedWeapon(int selectedWeaponIndex)
        {
            return selectedWeaponIndex switch
            {
                0 => secondaryWeaponList.Contains(secondaryWeapons.Boomerang),
                1 => secondaryWeaponList.Contains(secondaryWeapons.Bomb),
                2 => secondaryWeaponList.Contains(secondaryWeapons.Bow),
                3 => secondaryWeaponList.Contains(secondaryWeapons.Fire),
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
            if (!usingSecondaryWeapon && !link.inventory.primaryWeaponManager.usingPrimaryWeapon && secondaryWeapon != null)
            {
                secondaryWeapon.Attack();
                usingSecondaryWeapon = true;
            }
        }

        internal Rectangle getRect()
        {
            return new Rectangle(secondaryWeapon.getXPos(), secondaryWeapon.getYPos(), secondaryWeapon.getWidth(), secondaryWeapon.getHeight());
        }

        internal void SetSecondaryWeapon(int weapon)
        {
            if (HasSelectedWeapon(weapon))
            {
                secondaryWeapon = getSecondaryWeaponTypeByInt(weapon);
            }
        }
    }
}
