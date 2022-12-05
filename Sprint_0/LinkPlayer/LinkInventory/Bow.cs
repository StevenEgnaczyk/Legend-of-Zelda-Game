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
    public class Bow : ISecondaryWeapon
    {
        //weapon properties
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D arrow;
        private bool goingOut;

        private Rectangle sourceRect;

        private int height;
        private int width;

        private int distanceToTravel = 150;
        private int incrementalDistance = 45;

        private int bufferFrame;
        private int maxFrames = 5;

        //state list
        enum startingState
        {
            Down,
            Up,
            Left,
            Right
        }

        private startingState linkState;

        public Bow(Link link)
        {
            this.link = link;
        }

        //gets target rect
        private Vector2 getTargetRect(Vector2 startRect)
        {
            Vector2 targetRect = new();

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

        //gets starting rect
        private Vector2 getStartingRect()
        {
            Vector2 startingRect = new();

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
            Texture2D arrow = Texture2DStorage.GetItemSpritesheet();
            Rectangle sourceRect = ItemRectStorage.getUpArrowSprite();
            if (linkState == startingState.Down)
            {
               sourceRect = ItemRectStorage.getDownArrowSprite();
            }else if (linkState == startingState.Right)
            {
                sourceRect = ItemRectStorage.getRightArrowSprite();
            }else if (linkState == startingState.Left)
            {
                sourceRect = ItemRectStorage.getLeftArrowSprite();
            }

            Rectangle destinationRect = new((int)current.X, (int)current.Y, sourceRect.Width * 3, sourceRect.Height * 3);
            spriteBatch.Draw(arrow, destinationRect, sourceRect, Color.White);
            updateHeightAndWidth(destinationRect);
        }

        //updates for animation
        public void Update()
        {

            if (goingOut && Math.Abs(end.X - current.X) < 10 && Math.Abs(end.Y - current.Y) < 10)
            {
                link.inventory.secondaryWeaponManager.stopUsingWeapon();
            }

            if (OutOfBoundsTest.itemOutOfBounds((int)current.X, (int)current.Y))
            {
                link.inventory.secondaryWeaponManager.stopUsingWeapon();
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

        //attacks with links direction
        public void Attack()
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

            start = getStartingRect();
            end = getTargetRect(start);
            current = start;

            goingOut = true;
            distanceToTravel = 500;
            bufferFrame = 0;
            AudioStorage.GetArrow().Play();

            arrow = Texture2DStorage.GetItemSpritesheet();
            updateHeightAndWidth(sourceRect);
        }
    }

}