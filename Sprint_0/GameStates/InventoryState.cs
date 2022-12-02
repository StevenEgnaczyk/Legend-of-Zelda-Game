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
        //state properties
        private Game1 game;
        private bool transitioning;
        private int currentOffset;
        private ChangeToGameplayStateCommand command;

        public InventoryState(Game1 game)
        {
            this.game = game;
            command = new ChangeToGameplayStateCommand(game);

        }

        //set transition
        public void changeToTransitioning()
        {
            this.transitioning = true;
            this.currentOffset = 0;
        }

        //handles drawing transition or inventory drawing
        public void Draw(SpriteBatch spriteBatch)
        {


            if (transitioning)
            {
                game.roomManager.drawRoom(spriteBatch);
                game.link.Draw(spriteBatch);
                game.HUD.Draw(spriteBatch, 0, 704 + currentOffset);
                game.link.inventory.Draw(spriteBatch, 0, currentOffset);

            } else
            {
                game.HUD.Draw(spriteBatch, 0, 704);
                game.link.inventory.DrawInventory(spriteBatch);
            }
        }

        public void Update()
        {
            if (transitioning)
            {
                currentOffset-=10;
                if (currentOffset <= -704)
                {
                    transitioning = false;
                    command.Execute();
                }
            } else
            {
                //Process Keyboard Input
                game.keyboardController.ProcessInput(this);
            }
        }
    }
}
