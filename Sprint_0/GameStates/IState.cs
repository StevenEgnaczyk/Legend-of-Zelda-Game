using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public interface IState
    {

        public void Draw(SpriteBatch spriteBatch);
        public void Update();

        public void changeToTransitioning();
    }
}
