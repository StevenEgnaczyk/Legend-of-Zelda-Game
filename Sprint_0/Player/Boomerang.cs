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
    public class Boomerang : IWeapon
    {
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D boomerang;
        private Boolean goingOut;

        private Rectangle sourceRect;

        private int distanceToTravel = 50;
        private int incrementalDistance = 5;

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


        public Boomerang(Link link)
        {
            this.link = link;

            if (link.state.ToString().Equals("DownMovingLinkState"))
            {
                linkState = startingState.Down;
                sourceRect = new Rectangle(120, 30, 8, 5);

            }
            else if (link.state.ToString().Equals("UpMovingLinkState"))
            {
                linkState = startingState.Up;
                sourceRect = new Rectangle(135, 30, 8, 5);

            }
            else if (link.state.ToString().Equals("LeftMovingLinkState"))
            {
                linkState = startingState.Left;
                sourceRect = new Rectangle(129, 3, 5, 8);

            }
            else if (link.state.ToString().Equals("RightMovingLinkState"))
            {
                linkState = startingState.Right;
                sourceRect = new Rectangle(129, 28, 5, 8);

            }

            start = getStartingRect();
            end = getTargetRect(start);
            current = start;
            
            goingOut = true;
            distanceToTravel = 150;
            bufferFrame = 0;

            boomerang = Texture2DStorage.GetItemSpritesheet();




        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRect = new Rectangle((int)current.X, (int)current.Y, sourceRect.Width * 4, sourceRect.Height * 4);
            spriteBatch.Draw(boomerang, destinationRect, sourceRect, Color.White);

        }

        public void Update()
        {
            if (goingOut && ((Math.Abs(end.X - current.X) < 1) && (Math.Abs(end.Y - current.Y) < 1))) {
                goingOut = false;
            } else if (!goingOut && ((Math.Abs(start.X - current.X) < 1) && (Math.Abs(start.Y - current.Y) < 1)))
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
                    if (goingOut)
                    {
                        current.Y = (int)current.Y + incrementalDistance;
                    }
                    else
                    {
                        current.Y = (int)current.Y - incrementalDistance;
                    }

                }
                else if (linkState.Equals(startingState.Up))
                {
                    current.X = (int)current.X;

                    if (goingOut)
                    {
                        current.Y = (int)current.Y - incrementalDistance;
                    }
                    else
                    {
                        current.Y = (int)current.Y + incrementalDistance;
                    }
                }
                else if (linkState.Equals(startingState.Left))
                {
                    if (goingOut)
                    {
                        current.X = (int)current.X - incrementalDistance;
                    }
                    else
                    {
                        current.X = (int)current.X + incrementalDistance;
                    }
                    current.Y = (int)current.Y;

                }
                else if (linkState.Equals(startingState.Right))
                {
                    if (goingOut)
                    {
                        current.X = (int)current.X + incrementalDistance;
                    }
                    else
                    {
                        current.X = (int)current.X - incrementalDistance;
                    }
                    current.Y = (int)current.Y;

                }
            }
            

        }

        public Vector2 getTargetRect(Vector2 startRect)
        {
            Vector2 targetRect = new Vector2();
    
            if (linkState.Equals(startingState.Down))
            {
                Debug.WriteLine(distanceToTravel);
                targetRect.X = startRect.X;
                targetRect.Y = (startRect.Y + distanceToTravel);

            } else if (linkState.Equals(startingState.Up))
            {
                targetRect.X = startRect.X;
                targetRect.Y = (startRect.Y - distanceToTravel);

            } else if (linkState.Equals(startingState.Left))
            {
                targetRect.X = (startRect.X - distanceToTravel);
                targetRect.Y = startRect.Y;

            } else if (linkState.Equals(startingState.Right))
            {
                targetRect.X = (startRect.X + distanceToTravel);
                targetRect.Y = startRect.Y;

            }

            Debug.WriteLine(targetRect.ToString());

            return targetRect;

        }

        public Vector2 getStartingRect()
        {
            Vector2 startingRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                Debug.WriteLine(distanceToTravel);
                startingRect.X = link.xPos + 32;
                startingRect.Y = link.yPos + 64;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos + 32;
                startingRect.Y = link.yPos - 16;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos;
                startingRect.Y = link.yPos;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 64;
                startingRect.Y = link.yPos + 16;

            }

            return startingRect;

        }
    }
}
