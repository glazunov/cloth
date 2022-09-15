using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlaneCut
{
	public class GameStateMovingThroughCut : IGameState
	{
		private IMeshCreatable _meshCreator;
		private PlanePiece.Factory _planePieceFactory;

		[Inject]
		GameStateMovingThroughCut(PlanePiece.Factory planePieceFactory, IMeshCreatable meshCreatable)
		{
			_planePieceFactory = planePieceFactory;
			_meshCreator = meshCreatable;
		}

		public void Enter()
		{
			List<PlanePiece> pieces = new List<PlanePiece>();

			foreach (var item in _meshCreator.Meshes.Keys) {
				var piece = _planePieceFactory.Create(item, _meshCreator.Meshes[item]);
				pieces.Add(piece);
			}
		}

	}
}