using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Player
{
    public class Boomerang
    {
        private Link link;
        private Vector2 start;
        private Vector2 end;
        private Vector2 current;
        private Texture2D boomerang;
        private Boolean goingOut;

        private int distanceToTravel;
        private int incrementalDistance;


        public Boomerang(Link link)
        {
            this.link = link;
            this.start = new Vector2(link.xPos, link.yPos);
            this.current = start;
            this.boomerang = Texture2DStorage.GetItemSpritesheet();
            goingOut = true;
            distanceToTravel = 50;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(129, 3, 5, 8);
            Vector2 targetPos = getTargetRect(start);
            Rectangle destinationRect = new Rectangle((int)current.X, (int)current.Y, 5, 8);
            spriteBatch.Draw(boomerang, destinationRect, sourceRect, Color.White);

        }

        public void Update()
        {
            if (link.state.GetType().Equals("DownMovingLinkState"))
            {
                current.X = (int)current.X;
                if (goingOut)
                {
                    current.Y = (int)current.Y + incrementalDistance;
                } else
                {
                    current.Y = (int)current.Y - incrementalDistance;
                }

            }
            else if (link.state.GetType().Equals("UpMovingLinkState"))
            {
                current.X = (int)current.X;

                if (goingOut)
                {
                    current.Y = (int)current.Y - incrementalDistance;
                } else
                {
                    current.Y = (int)current.Y + incrementalDistance;
                }
            }
            else if (link.state.GetType().Equals("LeftMovingLinkState"))
            {
                if (goingOut)
                {
                    current.X = (int)current.X - incrementalDistance;
                } else
                {
                    current.X = (int)current.X + incrementalDistance;
                }
                current.Y = (int)current.Y;

            }
            else if (link.state.GetType().Equals("RightMovingLinkState"))
            {
                current.X = (int)current.X + incrementalDistance;
                current.Y = (int)current.Y;

            }
            

        }

        public Vector2 getTargetRect(Vector2 startRect)
        {
            Vector2 targetRect = new Vector2();

            if (link.state.GetType().Equals("DownMovingLinkState"))
            {
                targetRect.X = (int)startRect.X;
                targetRect.Y = (int)startRect.Y + distanceToTravel;

            } else if (link.state.GetType().Equals("UpMovingLinkState"))
            {
                targetRect.X = (int)startRect.X;
                targetRect.Y = (int)startRect.Y - distanceToTravel;

            } else if (link.state.GetType().Equals("LeftMovingLinkState"))
            {
                targetRect.X = (int)startRect.X - distanceToTravel;
                targetRect.Y = (int)startRect.Y;

            } else if (link.state.GetType().Equals("RightMovingLinkState"))
            {
                targetRect.X = (int)startRect.X + distanceToTravel;
                targetRect.Y = (int)startRect.Y;

            } else
            {
                targetRect.X = startRect.X;
                targetRect.Y = startRect.Y;
            }

            return targetRect;

        }
    }
}
