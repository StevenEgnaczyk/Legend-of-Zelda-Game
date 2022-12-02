using Microsoft.Xna.Framework.Graphics;
using Sprint_0;
using System;

namespace Sprint_0.Commands.GameCommands
{
    public class TransitionToInventoryCommand : ICommand
    {

        private Game1 theGame;

        public TransitionToInventoryCommand(Game1 game)
        {
            theGame = game;
        }

        public void Execute()
        {
            //begin transition animaiton from game to inventory
            theGame.currentGameState.changeToTransitioning();

        }
    }
}