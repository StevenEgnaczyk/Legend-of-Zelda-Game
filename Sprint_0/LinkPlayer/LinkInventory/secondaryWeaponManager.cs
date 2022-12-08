using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class secondaryWeaponManager
    {


        //Possible Secondary Weapons
        public enum secondaryWeapons
        {
            Boomerang,
            Bow,
            Bomb,
            Fire,
            None
        }

        //Current SecondaryWeapon
        public secondaryWeapons secondaryWeapon;
        public ISecondaryWeapon currentWeaponInterface;
        public bool hasSecondaryWeapon;
        public bool usingSecondaryWeapon = false;
        public bool weaponIsBomb = false;

        public List<secondaryWeapons> secondaryWeaponList{ get; set; }

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;

        private Link link;

        //sets default
        public secondaryWeaponManager(Link link)
        {
            this.link = link;
            secondaryWeaponList = new();
            secondaryWeapon = secondaryWeapons.None;
            hasSecondaryWeapon = false;
            usingSecondaryWeapon = false;
        }

        //adds weapon to link inventory
        public void AddSecondaryWeapon(secondaryWeapons weapon)
        {
            secondaryWeaponList.Add(weapon);
            if (secondaryWeapon == secondaryWeapons.None)
            {
                secondaryWeapon = weapon;
                currentWeaponInterface = getSecondaryWeaponInterfaceByEnum(secondaryWeapon);
                hasSecondaryWeapon = true;
                if(weapon == secondaryWeapons.Bomb)
                {
                    weaponIsBomb = true;
                }
                link.inventory.inventoryManager.setSelectedSecondaryWeaponIndex(weapon);
            }
            
            

        }

        //update manager for selected weapon or new weapons
        public void Update()
        {
            if (usingSecondaryWeapon)
            {
                usingSecondaryWeapon = true;
                currentWeaponInterface.Update();
            }
        }

        private ISecondaryWeapon getSecondaryWeaponInterfaceByEnum(secondaryWeapons secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                secondaryWeaponManager.secondaryWeapons.Fire => new Fire(link),
                secondaryWeaponManager.secondaryWeapons.Bow => new Bow(link),
                secondaryWeaponManager.secondaryWeapons.Bomb => new Bomb(link),
                secondaryWeaponManager.secondaryWeapons.Boomerang => new Boomerang(link),
                _ => null,
            };
        }
            
        //returns weapon type from integer index
        public secondaryWeaponManager.secondaryWeapons getSecondaryWeaponTypeByInt(int secondaryWeapon)
        {
            return secondaryWeapon switch
            {
                0 => secondaryWeapons.Boomerang,
                1 => secondaryWeapons.Bomb,
                2 => secondaryWeapons.Bow,
                3 => secondaryWeapons.Fire,
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
                currentWeaponInterface.Draw(spriteBatch);
            }
        }

        //sets using var to false
        internal void stopUsingWeapon()
        {
            usingSecondaryWeapon = false;
        }

        //initiates attack for respective selected weapon
        public void UseSecondaryWeapon()
        {
            if (!usingSecondaryWeapon && !link.inventory.primaryWeaponManager.usingPrimaryWeapon && secondaryWeapon != secondaryWeapons.None)
            {
                if (weaponIsBomb)
                {
                    if (link.inventory.getBombs() > 0)
                    {
                        currentWeaponInterface.Attack();
                        usingSecondaryWeapon = true;
                        link.inventory.removeBombs();
                    }
                }
                else
                {
                    currentWeaponInterface.Attack();
                    usingSecondaryWeapon = true;
                }
            }
        }

        //returns rectangle for selected weapon
        internal Rectangle getRect()
        {
            return new Rectangle(currentWeaponInterface.getXPos(), currentWeaponInterface.getYPos(), currentWeaponInterface.getWidth(), currentWeaponInterface.getHeight());
        }

        //sets secondary weapon if it is in link's inventory, accounts for one time use of bomb
        internal void SetSecondaryWeapon(int weapon)
        {
            if (HasSelectedWeapon(weapon))
            {
                secondaryWeapon = getSecondaryWeaponTypeByInt(weapon);
            }
            if (weapon == 1)
            {
                weaponIsBomb = true;
            }
            else
            {
                weaponIsBomb = false;
            }

            currentWeaponInterface = getSecondaryWeaponInterfaceByEnum(secondaryWeapon);
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
            secondaryWeapon = secondaryWeapons.None;
            hasSecondaryWeapon = false;
        }

        //sets the secondary weapon from integer index
        internal void setSecondaryWeaponTypeByInt(int selectedWeaponIndex)
        {
            switch(selectedWeaponIndex)
            {
                case 0: secondaryWeapon = secondaryWeapons.Boomerang; break;
                case 1: secondaryWeapon = secondaryWeapons.Bomb; break;
                case 2: secondaryWeapon = secondaryWeapons.Bow; break;
                case 3: secondaryWeapon = secondaryWeapons.Fire; break;
            }

            currentWeaponInterface = getSecondaryWeaponInterfaceByEnum(secondaryWeapon);
        }
    }
}
