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
    public class Fire : IWeapon
    {
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D fire;
        private bool goingOut;

        private Rectangle sourceRect;
        private const int height = 16;
        private const int width = 16;

        private int distanceToTravel = 100;
        private int incrementalDistance = 5;

        private int bufferFrame;
        private int maxFrames = 5;

        private int fireSpriteIndex = 0;
        private int bufferIndex = 0;
        private int bufferMax = 20;

        enum startingState
        {
            Down,
            Up,
            Left,
            Right
        }

        private static List<Rectangle> fireSprite = new List<Rectangle>()
        {
            new Rectangle(52, 11, 16, 16),
            new Rectangle(69, 11, 16, 16)
        };

        private startingState linkState;


        public Fire(Link link)
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
            start = getStartingRect();
            end = getTargetRect(start);
            current = start;

            goingOut = true;
            distanceToTravel = 500;
            bufferFrame = 0;

            fire = Texture2DStorage.GetOldManSpriteSheet();
        }

        private Vector2 getTargetRect(Vector2 startRect)
        {
            Vector2 targetRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                targetRect.X = startRect.X;
                targetRect.Y = startRect.Y + distanceToTravel;

            }
            else if (linkState.Equals(startingState.Up))
            {
                targetRect.X = startRect.X;
                targetRect.Y = startRect.Y - distanceToTravel;

            }
            else if (linkState.Equals(startingState.Left))
            {
                targetRect.X = startRect.X - distanceToTravel;
                targetRect.Y = startRect.Y;

            }
            else if (linkState.Equals(startingState.Right))
            {
                targetRect.X = startRect.X + distanceToTravel;
                targetRect.Y = startRect.Y;

            }

            Debug.WriteLine(targetRect);

            return targetRect;
        }

        private Vector2 getStartingRect()
        {
            Vector2 startingRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                startingRect.X = link.xPos + 8;
                startingRect.Y = link.yPos + 48;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos;
                startingRect.Y = link.yPos - 48;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos - 48;
                startingRect.Y = link.yPos + 16;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 48;
                startingRect.Y = link.yPos + 8;

            }

            return startingRect;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = fireSprite[fireSpriteIndex];
            Rectangle destinationRect = new Rectangle((int)current.X, (int)current.Y, sourceRect.Width * 3, sourceRect.Height * 3);
            spriteBatch.Draw(fire, destinationRect, sourceRect, Color.White);

        }

        public void Update()
        {
            Debug.WriteLine(current.ToString());
            Debug.WriteLine(end.ToString());

            if (goingOut && Math.Abs(end.X - current.X) < 10 && Math.Abs(end.Y - current.Y) < 10)
            {
                link.inventory.stopUsingWeapon();
            }

            bufferFrame++;
            if (bufferFrame > maxFrames)
            {
                bufferFrame = 0;
                if (linkState.Equals(startingState.Down))
                {
                    current.X = (int)current.X;
                    current.Y = (int)current.Y + incrementalDistance;

                }
                else if (linkState.Equals(startingState.Up))
                {
                    current.X = (int)current.X;
                    current.Y = (int)current.Y - incrementalDistance;

                }
                else if (linkState.Equals(startingState.Left))
                {
                    current.X = (int)current.X - incrementalDistance;
                    current.Y = (int)current.Y;

                }
                else if (linkState.Equals(startingState.Right))
                {
                    current.X = (int)current.X + incrementalDistance;
                    current.Y = (int)current.Y;
                }
            }

            bufferIndex++;

            if (bufferIndex == bufferMax)
            {
                bufferIndex = 0;
                fireSpriteIndex++;
                if (fireSpriteIndex == 2)
                {
                    fireSpriteIndex = 0;
                }
            }

        }

        /*
         * Getter methods 
        */
        public int getXPos()
        {
            return (int) current.X;
        }

        public int getYPos()
        {
            return (int) current.Y;
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