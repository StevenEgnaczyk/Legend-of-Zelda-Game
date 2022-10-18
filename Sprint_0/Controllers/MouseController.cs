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

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void ProcessInput()
    {
        MouseState mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Released)
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            if (mousePos.X > 850 && mousePos.X < 874 && mousePos.Y > 225 && mousePos.Y < 273)
            {
                nextMapCommand.Execute();
            }
        }

        if (mouseState.RightButton == ButtonState.Released)
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            if (mousePos.X > 850 && mousePos.X < 874 && mousePos.Y > 225 && mousePos.Y < 273)
            {
                prevMapCommand.Execute();
            }
        }

    }
}
