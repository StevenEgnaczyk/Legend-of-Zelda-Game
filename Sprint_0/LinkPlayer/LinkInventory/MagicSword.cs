using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.LinkPlayer.LinkInventory
{
    public class MagicSword : IWeapon
    {
        private Link link;
        private Texture2D magicSword;

        private Rectangle sourceRect;
        private Vector2 startingRect;

        private int xPos;
        private int yPos;
        private int height;
        private int width;
        
        private int magicSwordIndex;
        private int maxFrames = 3;
        private int bufferIndex = 0;
        private int bufferMax = 5;

        enum startingState
        {
            Down,
            Up,
            Left,
            Right
        }

        private startingState linkState;


        public MagicSword(Link link)
        {
            if (link.state.ToString().Equals("DownMovingLinkState"))
            {
                linkState = startingState.Down;
            }
            else if (link.state.ToString().Equals("UpMovingLinkState"))
            {
                linkState = startingState.Up;
            }
            else if (link.state.ToString().Equals("LeftMovingLinkState"))
            {
                linkState = startingState.Left;
            }
            else if (link.state.ToString().Equals("RightMovingLinkState"))
            {
                linkState = startingState.Right;
            }

            this.link = link;
            bufferIndex = 0;
            magicSwordIndex = 0;
            magicSword = Texture2DStorage.GetLinkSpriteSheet();
            startingRect = getStartingRect();
        }
        private Vector2 getStartingRect()
        {
            Vector2 startingRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                startingRect.X = link.xPos + 24;
                startingRect.Y = link.yPos + 48;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos + 12;
                startingRect.Y = link.yPos - 48;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos - 38;
                startingRect.Y = link.yPos + 24;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 48;
                startingRect.Y = link.yPos + 16;

            }

            return startingRect;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle();
            Rectangle destinationRect = new Rectangle();

            switch (linkState)
            {
                case startingState.Down:
                    sourceRect = LinkRectStorage.getDownMagicSwordRectangle(magicSwordIndex);
                    destinationRect = new Rectangle((int)startingRect.X, (int)startingRect.Y, sourceRect.Width * 4, sourceRect.Height * 4);
                    break;
                case startingState.Right:
                    sourceRect = LinkRectStorage.getRightMagicSwordRectangle(magicSwordIndex);
                    destinationRect = new Rectangle((int)startingRect.X, (int)startingRect.Y, sourceRect.Width * 4, sourceRect.Height * 4);
                    break;
                case startingState.Left:
                    sourceRect = LinkRectStorage.getLeftMagicSwordRectangle(magicSwordIndex);
                    destinationRect = new Rectangle((int)startingRect.X + (sourceRect.Width - 13), (int)startingRect.Y, sourceRect.Width * 4, sourceRect.Height * 4);
                    break;
                case startingState.Up:
                    sourceRect = LinkRectStorage.getUpMagicSwordRectangle(magicSwordIndex);
                    destinationRect = new Rectangle((int)startingRect.X, (int)startingRect.Y + (sourceRect.Height - 14), sourceRect.Width * 4, sourceRect.Height * 4);
                    break;
            }


            spriteBatch.Draw(magicSword, destinationRect, sourceRect, Color.White);
            updatePositionAndDimensions(destinationRect);

        }

        public void Update()
        {
            bufferIndex++;

            if (bufferIndex == bufferMax)
            {
                bufferIndex = 0;
                magicSwordIndex++;
                if (magicSwordIndex == maxFrames)
                {
                    link.inventory.stopUsingWeapon();
                    magicSwordIndex = 0;
                }
            }

        }

        private void updatePositionAndDimensions(Rectangle rec)
        {
            xPos = rec.X;
            yPos = rec.Y;
            height = rec.Height;
            width = rec.Width;
        }

        /* 
         * Getter methods
         */
        public int getXPos()
        {
            return xPos;
        }
        
        public int getYPos()
        {
            return yPos;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }
    }

}