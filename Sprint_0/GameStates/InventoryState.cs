using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public class InventoryState : IState
    {

        private Game1 game;

        public InventoryState(Game1 game)
        {
            this.game = game;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            game.HUD.Draw(spriteBatch);
        }

        public void Update()
        {
            //Process Keyboard Input
            game.keyboardController.ProcessInput();
            game.mouseController.ProcessInput();
        }
    }
}
