using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0;
using Sprint_0.GameStates;
using System;
using System.Diagnostics;
using System.Threading;

public class MouseController : IController
{
    private MouseState lastMouseState;


    public MouseController(ContentManager c, RoomManager room)
    {

    }

    public void HandleEvents()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void ProcessInput(IState gameplayState)
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
            }
        }
        //sets last state to current to stop fast map switching
        lastMouseState = mouseState;

    }
}
