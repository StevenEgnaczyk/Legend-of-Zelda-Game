using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.GameStates
{
    public class RoomTransitionState : IState
    {
        //state properties
        private Game1 game;
        private bool fadeOut;
        private ChangeToGameplayStateCommand command;
        private int room;

        float alpha;
        
        //transition between rooms
        public RoomTransitionState(Game1 game, int roomToTeleport)
        {
            this.game = game;
            this.fadeOut = true;
            command = new ChangeToGameplayStateCommand(game);
            room = roomToTeleport;
            alpha = 0f;

        }

        //set transition
        public void changeToTransitioning()
        {
            this.alpha = 255;
            this.fadeOut = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!fadeOut)
            {
                game.link.Draw(spriteBatch);
            }
            game.roomManager.drawRoom(spriteBatch);
            Texture2D blackBackground = Texture2DStorage.GetDaBaby();
            Debug.WriteLine(alpha);
            spriteBatch.Draw(blackBackground, new Rectangle(0, 0, 1200, 1000), new Color(Color.White, (int)alpha));
            

        }

        public void Update()
        {
            if (fadeOut)
            {
                alpha += 10f;
                if (alpha >= 255)
                {
                    game.roomManager.loadRoom(room);
                    changeToTransitioning();
                }
            } else
            {
                alpha -= 10f;
                if (alpha <= 0)
                {
                    command.Execute();
                }
            }
        }
    }
}
