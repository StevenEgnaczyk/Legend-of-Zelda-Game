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
    public class Boomerang : IWeapon
    {
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D boomerang;
        private bool goingOut;

        private Rectangle sourceRect;
        private int height;
        private int width;

        private int distanceToTravel = 150;
        private int incrementalDistance = 25;

        private int bufferIndex;
        private int bufferMax = 15;

        private int bufferFrame;
        private int maxFrames = 5;

        private int boomerangSpriteIndex;

        private static List<Rectangle> boomerangSprite = new()
        {
            new Rectangle(129, 3, 5, 8),
            new Rectangle(120, 30, 8, 5),
            new Rectangle(129, 28, 5, 8),
            new Rectangle(135, 30, 8, 5)
        };

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
                boomerangSpriteIndex = 1;

            }
            else if (link.state.ToString().Equals("UpMovingLinkState"))
            {
                linkState = startingState.Up;
                sourceRect = new Rectangle(135, 30, 8, 5);
                boomerangSpriteIndex = 3;

            }
            else if (link.state.ToString().Equals("LeftMovingLinkState"))
            {
                linkState = startingState.Left;
                sourceRect = new Rectangle(129, 3, 5, 8);
                boomerangSpriteIndex = 0;

            }
            else if (link.state.ToString().Equals("RightMovingLinkState"))
            {
                linkState = startingState.Right;
                sourceRect = new Rectangle(129, 28, 5, 8);
                boomerangSpriteIndex = 2;

            }

            start = getStartingRect();
            end = getTargetRect(start);
            current = start;

            goingOut = true;
            distanceToTravel = 150;
            bufferFrame = 0;

            boomerang = Texture2DStorage.GetItemSpritesheet();
            updateHeightAndWidth(sourceRect);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRect = boomerangSprite[boomerangSpriteIndex];
            Rectangle destinationRect = new Rectangle((int)current.X, (int)current.Y, sourceRect.Width * 5, sourceRect.Height * 5);
            spriteBatch.Draw(boomerang, destinationRect, sourceRect, Color.White);

            updateHeightAndWidth(sourceRect);

        }

        public void Update()
        {
            if (goingOut && Math.Abs(end.X - current.X) < 1 && Math.Abs(end.Y - current.Y) < 1)
            {
                goingOut = false;
            }
            else if (!goingOut && Math.Abs(start.X - current.X) < 1 && Math.Abs(start.Y - current.Y) < 1)
            {
                link.inventory.weaponManager.stopUsingWeapon();
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

            bufferIndex++;

            if (bufferIndex == bufferMax)
            {
                bufferIndex = 0;
                boomerangSpriteIndex++;
                if (boomerangSpriteIndex == 4)
                {
                    boomerangSpriteIndex = 0;
                }
            }


        }

        public Vector2 getTargetRect(Vector2 startRect)
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

            Debug.WriteLine(targetRect.ToString());

            return targetRect;

        }

        public Vector2 getStartingRect()
        {
            Vector2 startingRect = new Vector2();

            if (linkState.Equals(startingState.Down))
            {
                startingRect.X = link.xPos + 16;
                startingRect.Y = link.yPos + 64;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos + 8;
                startingRect.Y = link.yPos - 16;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos - 16;
                startingRect.Y = link.yPos + 16;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 64;
                startingRect.Y = link.yPos + 16;

            }

            return startingRect;

        }

        private void updateHeightAndWidth(Rectangle rec)
        {
            height = rec.Height;
            width = rec.Width;
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
