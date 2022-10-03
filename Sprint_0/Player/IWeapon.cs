using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Player
{
    public interface IWeapon
    {
        void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
        void Update();
    }
}
