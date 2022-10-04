﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Player
{
    public class Bow : IWeapon
    {
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D arrow;
        private Boolean goingOut;

        private Rectangle sourceRect;

        private int distanceToTravel = 300;
        private int incrementalDistance = 30;

        private int bufferFrame;
        private int maxFrames = 5;

        enum startingState
        {
            Down,
            Up,
            Left,
            Right
        }

        private startingState linkState;

        public Bow(Link link, String arrowType)
        {
            if (arrowType.Equals("Red"))
            {
                if (link.state.ToString().Equals("DownMovingLinkState"))
                {
                    linkState = startingState.Down;
                    sourceRect = new Rectangle(154, 44, 5, 16);

                }
                else if (link.state.ToString().Equals("UpMovingLinkState"))
                {
                    linkState = startingState.Up;
                    sourceRect = new Rectangle(154, 0, 5, 16);

                }
                else if (link.state.ToString().Equals("LeftMovingLinkState"))
                {
                    linkState = startingState.Left;
                    sourceRect = new Rectangle(148, 38, 16, 5);

                }
                else if (link.state.ToString().Equals("RightMovingLinkState"))
                {
                    linkState = startingState.Right;
                    sourceRect = new Rectangle(148, 32, 16, 5);

                }
            }
            else
            {
                if (arrowType.Equals("Blue"))
                {
                    if (link.state.ToString().Equals("DownMovingLinkState"))
                    {
                        linkState = startingState.Down;
                        sourceRect = new Rectangle(171, 35, 5, 16);

                    }
                    else if (link.state.ToString().Equals("UpMovingLinkState"))
                    {
                        linkState = startingState.Up;
                        sourceRect = new Rectangle(154, 16, 5, 16);

                    }
                    else if (link.state.ToString().Equals("LeftMovingLinkState"))
                    {
                        linkState = startingState.Left;
                        sourceRect = new Rectangle(178, 34, 16, 5);

                    }
                    else if (link.state.ToString().Equals("RightMovingLinkState"))
                    {
                        linkState = startingState.Right;
                        sourceRect = new Rectangle(178, 40, 16, 5);

                    }

                }
            }

            this.link = link;
            start = getStartingRect();
            end = getTargetRect(start);
            current = start;

            goingOut = true;
            distanceToTravel = 500;
            bufferFrame = 0;

            arrow = Texture2DStorage.GetItemSpritesheet();

            Debug.WriteLine(linkState.ToString());
        }

        private Vector2 getTargetRect(Vector2 startRect)
        {
            Vector2 targetRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                targetRect.X = startRect.X;
                targetRect.Y = (startRect.Y + distanceToTravel);

            }
            else if (linkState.Equals(startingState.Up))
            {
                targetRect.X = startRect.X;
                targetRect.Y = (startRect.Y - distanceToTravel);

            }
            else if (linkState.Equals(startingState.Left))
            {
                targetRect.X = (startRect.X - distanceToTravel);
                targetRect.Y = startRect.Y;

            }
            else if (linkState.Equals(startingState.Right))
            {
                targetRect.X = (startRect.X + distanceToTravel);
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
                startingRect.X = link.xPos + 32;
                startingRect.Y = link.yPos + 64;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos + 16;
                startingRect.Y = link.yPos - 48;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos - 64;
                startingRect.Y = link.yPos + 32;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 64;
                startingRect.Y = link.yPos + 32;

            }

            return startingRect;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRect = new Rectangle((int)current.X, (int)current.Y, sourceRect.Width * 3, sourceRect.Height * 3);
            spriteBatch.Draw(arrow, destinationRect, sourceRect, Color.White);

        }

        public void Update()
        {
            Debug.WriteLine(current.ToString());
            Debug.WriteLine(end.ToString());

            if (goingOut && ((Math.Abs(end.X - current.X) < 10) && (Math.Abs(end.Y - current.Y) < 10)))
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


        }
    }

}