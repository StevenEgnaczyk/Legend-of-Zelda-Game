using Sprint_0.GameStates;
using System;

public interface IController
{

	void Update();

	void HandleEvents();

	void ProcessInput(IState gameplayState);

}
