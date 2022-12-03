using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Interfaces
{
    public interface ISecondaryWeapon
    {
        //required methods for interface
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
        void Update();
        int getXPos();
        int getYPos();
        int getHeight();
        int getWidth();
        void Attack();
    }
}
