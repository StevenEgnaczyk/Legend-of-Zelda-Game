using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public class DeathScreenState : IState
    {
        //state properties
        private Game1 game;
        private bool transitioning;
        private ChangeToGameplayStateCommand command;
        float a;

        public DeathScreenState(Game1 game)
        {
            this.game = game;
            this.transitioning = false;
            command = new ChangeToGameplayStateCommand(game);
            a = 255f;

        }

        public void changeToTransitioning()
        {
            this.transitioning = true;
        }

        //drawing death state
        public void Draw(SpriteBatch spriteBatch)
        {
            if (transitioning)
            {
                game.roomManager.drawRoom(spriteBatch);
            }
            Texture2D startUpScreen = Texture2DStorage.GetDeeathScreenSheet();
            Rectangle gameOverSourceRect = RoomRectStorage.getGameOverSourceRect();
            Rectangle gameOverDestRect = RoomRectStorage.getGameOverDestRect();
            spriteBatch.Draw(startUpScreen, gameOverDestRect, gameOverSourceRect,new Color(Color.White, (int) a));
        }

        //updating state to see transition or stable state
        public void Update()
        {
            if (transitioning)
            {
                a -= 5f;
                if (a <= 0)
                {
                    game.roomManager.loadRoom(game.link.currentRoom);
                    //game.roomManager.loadRoom(12);
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