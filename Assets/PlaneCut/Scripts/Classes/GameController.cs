using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

namespace PlaneCut
{
	public enum GameStates
	{
		Playing,
		GameOver
	}

	public class GameController : IDisposable
	{
		private IMeshCreatable _meshCreator;
		private PlanePiece.Factory _planePieceFactory;
		private GameStates _state = GameStates.Playing;
		private IGameState _gameStateMachine;

		private SignalBus _signalBus;

		[Inject]
		GameController(SignalBus signalBus, PlanePiece.Factory planePieceFactory, IMeshCreatable meshCreatable, IGameState gameStateMachine)
		{
			_signalBus = signalBus;
			_planePieceFactory = planePieceFactory;
			_meshCreator = meshCreatable;
			_gameStateMachine = gameStateMachine;
			Init();
		}

		public GameStates State {
			get { return _state; }
		}

		public void Dispose()
		{
			_signalBus.Unsubscribe<FinishedPlayerSignal>(OnPlayerFinished);
		}

		public void Init()
		{
			_signalBus.Subscribe<FinishedPlayerSignal>(OnPlayerFinished);
			_state = GameStates.Playing;

			List<PlanePiece> pieces = new List<PlanePiece>();

			foreach (var item in _meshCreator.Meshes.Keys) {
				var piece = _planePieceFactory.Create(item, _meshCreator.Meshes[item]);
				pieces.Add(piece);
			}
		}

		void OnPlayerFinished()
		{
			_state = GameStates.GameOver;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}
}