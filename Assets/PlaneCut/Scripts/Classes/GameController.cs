using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlaneCut
{


	public class GameController : IDisposable
	{
		private IGameStateMachine _gameStateMachine;
		private IGameState _moving;
		private IGameState _endMoving;
		private SignalBus _signalBus;

		[Inject]
		GameController(SignalBus signalBus,
			IGameStateMachine gameStateMachine,
			GameStateMovingThroughCut moving,
			GameStateEndMoving endMoving
			)
		{
			_signalBus = signalBus;
			_gameStateMachine = gameStateMachine;
			_moving = moving;
			_endMoving = endMoving;

			_gameStateMachine.ChangeState(_moving);
			_signalBus.Subscribe<FinishedPlayerSignal>(OnPlayerFinished);

		}		

		void OnPlayerFinished()
		{
			_gameStateMachine.ChangeState(_endMoving);
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<FinishedPlayerSignal>(OnPlayerFinished);
		}

	}
}