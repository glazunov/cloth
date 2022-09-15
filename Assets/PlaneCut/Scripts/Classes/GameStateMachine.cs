using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneCut
{
	public class StateMachine
	{
		IGameState currentState;

		public void ChangeState(IGameState newState)
		{
			if (currentState != null)
				currentState.Exit();

			currentState = newState;
			currentState.Enter();
		}

	}
}