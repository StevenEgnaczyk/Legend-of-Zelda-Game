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
        //IState required methods
        public void Draw(SpriteBatch spriteBatch);
        public void Update();

        public void changeToTransitioning();
    }
}
