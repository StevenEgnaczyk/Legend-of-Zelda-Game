using Sprint_0.GameStates;
using System;

public interface IController
{
    //required methods for interface
    void ProcessInput(IState gameplayState);

}
