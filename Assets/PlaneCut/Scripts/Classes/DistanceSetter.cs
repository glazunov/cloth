using UnityEngine;
using System;
using Zenject;

namespace PlaneCut
{
	public class DistanceSetter
	{
		[Inject]
		private Settings _settings;

		public void SetPosition(PlanePiece planePiece)
		{
			var dir = planePiece.Side == PieceSide.Left ? -1 : 1;

			planePiece.transform.position =
				planePiece.transform.right
				* _settings.distanceBetweenPieces / 2
				* dir;
		}

		[Serializable]
		public class Settings
		{
			[Range(0, 5)]
			public float distanceBetweenPieces;
		}
	}
}
