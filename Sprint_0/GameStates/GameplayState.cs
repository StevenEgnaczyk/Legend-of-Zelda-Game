using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public class GameplayState : IState
    {
        //gameplay state properties
        private Game1 game;
        private bool transitioning;
        private int currentOffset;
        private ChangeToInventoryStateCommand command;

        public GameplayState(Game1 game)
        {
            this.game = game;
            this.transitioning = false;
            command = new ChangeToInventoryStateCommand(game);

        }

        //set transition
        public void changeToTransitioning()
        {
            this.transitioning = true;
            this.currentOffset = -704;
        }

        //call room manager to get room drawn and handle transition to inventory
        public void Draw(SpriteBatch spriteBatch)
        {
            game.roomManager.drawRoom(spriteBatch);
            game.link.Draw(spriteBatch);

            if (transitioning)
            {
                game.HUD.Draw(spriteBatch, 0, 704 + currentOffset);
                game.link.inventory.Draw(spriteBatch, 0, currentOffset);
            } else
            {
                game.HUD.Draw(spriteBatch, 0, currentOffset);
            }
        }

        public void Update()
        {


            if (transitioning)
            {
                this.currentOffset+=10;
                if (this.currentOffset >= 0)
                {
                    this.transitioning = false;
                    this.command.Execute();
                }
            } else
            {
                //Process Keyboard Input
                game.keyboardController.ProcessInput(this);
                game.link.Update();
                game.roomManager.Update();
            }
        }
    }
}
