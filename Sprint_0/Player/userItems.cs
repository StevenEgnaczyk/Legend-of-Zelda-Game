using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Player
{
    public class userItems
    {
        public IWeapon currentWeapon;

        public static Boomerang boomerang;
        public static Bow bow;
        public static Bomb bomb;
        public static Fire fire;

        private Boolean hasWeapon = false;

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

        public void UseBow(String arrowType)
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
