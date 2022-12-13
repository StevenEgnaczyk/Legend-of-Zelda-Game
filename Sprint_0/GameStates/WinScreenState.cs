using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public class WinScreenState : IState
    {
        //state properties
        private Game1 game;
        private bool transitioning;
        private ChangeToGameplayStateCommand command;
        float alpha;

        public WinScreenState(Game1 game)
        {
            this.game = game;
            this.transitioning = false;
            command = new ChangeToGameplayStateCommand(game);
            alpha = 255f;

        }

        //set transition
        public void changeToTransitioning()
        {
            this.transitioning = true;

        }

        //draw screen
        public void Draw(SpriteBatch spriteBatch)
        {
            if (transitioning)
            {
                game.roomManager.drawRoom(spriteBatch);
            }
            Texture2D winScreen = Texture2DStorage.GetWinSpriteSheet();
            Rectangle winSourceRect = RoomRectStorage.getWinSourceRect();
            Rectangle winDestRect = RoomRectStorage.getWinDestRect();
            spriteBatch.Draw(winScreen, winDestRect, winSourceRect, new Color(Color.White, (int)alpha));
        }

        //wait for input then execute transition
        public void Update()
        {
            if (transitioning)
            {
                alpha -= 5f;
                if (alpha <= 0)
                {
                    game.roomManager.loadRoom(game.link.currentRoom);
                    //game.roomManager.loadRoom(12);
                    MediaPlayer.Play(AudioStorage.GetSong();
                    command.Execute();
                }
            }
            else
            {
                //Process Keyboard Input
                game.keyboardController.ProcessInput(this);
            }

        }
    }
}