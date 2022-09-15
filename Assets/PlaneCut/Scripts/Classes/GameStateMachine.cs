using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneCut
{
	public class GameStateMachine : IGameStateMachine
	{
		IGameState currentState;

		public void ChangeState(IGameState newState)
		{
			currentState = newState;
			currentState.Enter();
		}

	}
}