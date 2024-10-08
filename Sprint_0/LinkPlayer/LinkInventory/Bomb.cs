﻿using Microsoft.Xna.Framework;
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
    public class Bomb : ISecondaryWeapon
    {
        //bomb properties
        private Link link;
        private Texture2D bomb;
        private Vector2 startingRect;
     
        private int height;
        private int width;
        
        private int bombSpriteIndex = 0;
        private int maxFrames = 4;
        private int bufferIndex = 0;
        private int bufferMax = 50;
        
        //list of states
        enum startingState
        {
            Down,
            Up,
            Left,
            Right
        }

        private static List<Rectangle> bombSprites = new List<Rectangle>()
        {
            new Rectangle(136, 0, 8, 14),
            new Rectangle(113, 44, 10, 10),
            new Rectangle(125, 44, 10, 10),
            new Rectangle(137, 44, 12, 13)
        };

        private startingState linkState;


        public Bomb(Link link)
        { 
            this.link = link;
        }

        //gets starting rect
        private Vector2 getStartingRect()
        {
            Vector2 startingRect = new();

            if (linkState.Equals(startingState.Down))
            {
                startingRect.X = link.xPos + 16;
                startingRect.Y = link.yPos + 64;

            }
            else if (linkState.Equals(startingState.Up))
            {
                startingRect.X = link.xPos + 8;
                startingRect.Y = link.yPos - 64;

            }
            else if (linkState.Equals(startingState.Left))
            {
                startingRect.X = link.xPos - 48;
                startingRect.Y = link.yPos + 16;

            }
            else if (linkState.Equals(startingState.Right))
            {
                startingRect.X = link.xPos + 64;
                startingRect.Y = link.yPos + 16;

            }

            return startingRect;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D bomb = Texture2DStorage.GetItemSpritesheet();
            Rectangle sourceRect = bombSprites[bombSpriteIndex];
            Rectangle destinationRect = new Rectangle((int)startingRect.X, (int)startingRect.Y, sourceRect.Width * 4, sourceRect.Height * 4);
            spriteBatch.Draw(bomb, destinationRect, sourceRect, Color.White);
            updateHeightAndWidth(destinationRect);

        }

//update for animation, also plays sound
        public void Update()
        {
            if (bombSpriteIndex == 0)
            {
                bufferIndex++;
            }
            else
            {
                bufferIndex += 5;
            }

            if (bufferIndex == bufferMax)
            {
                bufferIndex = 0;
                bombSpriteIndex++;
                AudioStorage.GetBombBlow().Play();
                if (bombSpriteIndex == maxFrames)
                {
                    link.inventory.secondaryWeaponManager.stopUsingWeapon();
                    bombSpriteIndex = 0;
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
            return (int) startingRect.X;
        }

        public int getYPos()
        {
            return (int) startingRect.Y;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }

        //attacks checking starting direction
        public void Attack()
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

                bufferIndex = 0;
                AudioStorage.GetBombDrop().Play();

                bomb = Texture2DStorage.GetItemSpritesheet();
                startingRect = getStartingRect();
            }
        }

}