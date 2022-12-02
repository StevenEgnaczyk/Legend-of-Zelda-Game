using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        //manager attributes
        public ISecondaryWeapon secondaryWeapon{ get; set; }
        public bool hasSecondaryWeapon = false;

        //weapon list
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
        public bool weaponIsBomb = false;
        private Link link;

        //sets default
        public secondaryWeaponManager(Link link)
        {
            this.link = link;
            secondaryWeaponList = new List<secondaryWeapons>();
            secondaryWeapon = null;
        }

        //adds weapon to link inventory
        public void AddSecondaryWeapon(secondaryWeapons weapon)
        {
            if (secondaryWeaponList.Count == 0)
            {
                secondaryWeapon = getSecondaryWeaponTypeByEnum(weapon);
                if(weapon == secondaryWeapons.Bomb)
                {
                    weaponIsBomb = true;
                }
            }
            secondaryWeaponList.Add(weapon);
            link.inventory.inventoryManager.setSelectedSecondaryWeaponIndex(getSecondaryWeaponIndexByEnum(weapon));

        }

        //update manager for selected weapon or new weapons
        public void Update()
        {
            if (usingSecondaryWeapon)
            {
                usingSecondaryWeapon = true;
                secondaryWeapon.Update();
            }

            if (secondaryWeaponList.Count > 0)
            {
                hasSecondaryWeapon = true;
            } else
            {
                hasSecondaryWeapon = false;
            }
        }

        //returns weapon type from the list above
        public ISecondaryWeapon getSecondaryWeaponTypeByEnum(secondaryWeapons secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                secondaryWeaponManager.secondaryWeapons.Fire => new Fire(link),
                secondaryWeaponManager.secondaryWeapons.Bow => new Bow(link),
                secondaryWeaponManager.secondaryWeapons.Bomb => new Bomb(link),
                secondaryWeaponManager.secondaryWeapons.Boomerang => new Boomerang(link),
                _ => throw new NotImplementedException(),
            };
        }
            
        //returns weapon type from integer index
        public ISecondaryWeapon getSecondaryWeaponTypeByInt(int secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                0 => new Boomerang(link),
                1 => new Bomb(link),
                2 => new Bow(link),
                3 => new Fire(link),
                _ => throw new NotImplementedException(),
            };
        }

        //returns weapon respective integer index from the list above
        public int getSecondaryWeaponIndexByEnum(secondaryWeapons weapon)
        {
            return weapon switch
            {
                secondaryWeapons.Boomerang => 0,
                secondaryWeapons.Bomb => 1,
                secondaryWeapons.Bow => 2,
                secondaryWeapons.Fire => 3,
                _ => throw new NotImplementedException(),
            };
        }

        //returns weapon respective integer index from input of weapon type(not from list)
        public int getSecondaryWeaponIndexByEnum(ISecondaryWeapon weapon)
        {
            return weapon switch
            {
                Boomerang => 0,
                Bomb => 1,
                Bow => 2,
                Fire => 3,
                _ => throw new NotImplementedException(),
            };
        }

        //checks if the specified weapon type is selected
        internal bool HasSelectedWeapon(int selectedWeaponIndex)
        {
            return selectedWeaponIndex switch
            {
                0 => secondaryWeaponList.Contains(secondaryWeapons.Boomerang),
                1 => secondaryWeaponList.Contains(secondaryWeapons.Bomb),
                2 => secondaryWeaponList.Contains(secondaryWeapons.Bow),
                3 => secondaryWeaponList.Contains(secondaryWeapons.Fire),
                _ => throw new NotImplementedException(),
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

        //sets using var to false
        internal void stopUsingWeapon()
        {
            usingSecondaryWeapon = false;
        }

        //returns current selected secondary weapon
        public ISecondaryWeapon getSecondaryWeapon()
        {
            return secondaryWeapon;
        }

        //returns current selected secondary weapon's index
        public int getSecondaryWeaponIndex()
        {
            return getSecondaryWeaponIndexByEnum(secondaryWeapon);
        }

        //initiates attack for respective selected weapon
        public void UseSecondaryWeapon()
        {
            if (!usingSecondaryWeapon && !link.inventory.primaryWeaponManager.usingPrimaryWeapon && secondaryWeapon != null)
            {
                secondaryWeapon.Attack();
                usingSecondaryWeapon = true;
            }
        }

        //returns rectangle for selected weapon
        internal Rectangle getRect()
        {
            return new Rectangle(secondaryWeapon.getXPos(), secondaryWeapon.getYPos(), secondaryWeapon.getWidth(), secondaryWeapon.getHeight());
        }

        //sets secondary weapon if it is in link's inventory, accounts for one time use of bomb
        internal void SetSecondaryWeapon(int weapon)
        {
            if (HasSelectedWeapon(weapon))
            {
                secondaryWeapon = getSecondaryWeaponTypeByInt(weapon);
            }
            if(weapon == 1)
            {
                weaponIsBomb = true;
            }
            else
            {
                weaponIsBomb = false;
            }
        }

        //returns if the selected weapon is a bomb or not
        public bool bombSelected()
        {
            return weaponIsBomb;
        }

        //resets secondary weapons
        public void reset()
        {
            secondaryWeaponList = new List<secondaryWeapons>();
            secondaryWeapon = null;   
        }

        //sets the secondary weapon from integer index
        internal void setSecondaryWeaponTypeByInt(int selectedWeaponIndex)
        {
            switch(selectedWeaponIndex)
            {
                case 0: secondaryWeapon = new Boomerang(link); break;
                case 1: secondaryWeapon = new Bomb(link); break;
                case 2: secondaryWeapon = new Bow(link); break;
                case 3: secondaryWeapon = new Fire(link); break;
            }
        }
    }
}
