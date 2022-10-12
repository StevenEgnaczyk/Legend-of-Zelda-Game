using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class MouseController : IController
{

    private ICommand nextMapCommand;
    private ICommand prevMapCommand;

    public MouseController(ContentManager c, RoomManager room)
    {

        nextMapCommand = new NextMapCommand(room);
        prevMapCommand = new PrevMapCommand(room);

    }

    public void HandleEvents()
    {
        throw new NotImplementedException();
    }

    public void ProcessInput()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    internal void processInput(MouseState mouseState, SpriteBatch spriteBatch)
    {
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            if (mousePos.X > 0 && mousePos.X < 400 && mousePos.Y > 0 && mousePos.Y < 200)
            {
            }
        }
               
    }
}
