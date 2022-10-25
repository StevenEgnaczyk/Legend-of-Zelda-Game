using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using System;
using System.Diagnostics;
using System.Threading;

public class MouseController : IController
{

    private ICommand nextMapCommand;
    private ICommand prevMapCommand;
    private MouseState lastMouseState;


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
        //get mouse state
        MouseState mouseState = Mouse.GetState();
        //checks for press on mouse state
        if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton != ButtonState.Pressed)
        {
            //get mouse pos to make sure user clicks on map
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);

            if ((mousePos.X < 982 && mousePos.X > 950) && (mousePos.Y > 350 && mousePos.Y < 414))
            {
                nextMapCommand.Execute();
            }
        }
        //sets last state to current to stop fast map switching
        lastMouseState = mouseState;

    }
}
