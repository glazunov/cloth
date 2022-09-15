using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlaneCut
{
	public class ClothDensitySetter : MonoBehaviour
	{
		private MeshCreator.Settings _settings;

		[Inject]
		public void Construct(MeshCreator.Settings settings)
		{
			_settings = settings;
		}

		public void SetDensity(PlanePiece piece)
		{
			StartCoroutine(SetDensityCoroutine(piece));
		}

		IEnumerator SetDensityCoroutine(PlanePiece piece)
		{
			yield return null;
			ClothSkinningCoefficient[] newConstraints;
			newConstraints = piece.Cloth.coefficients;

			for(int i = 0; i < newConstraints.Length; i++) {
				newConstraints[i].maxDistance = i % ((int)_settings.planeWidth + 1 );
			}

			var lastVertsStartIndex = newConstraints.Length - newConstraints.Length % _settings.planeWidth;

			for (int i = newConstraints.Length - 1; i >= lastVertsStartIndex; i--) {
				newConstraints[i].maxDistance = 0;
			}

			piece.Cloth.coefficients = newConstraints;

		}

	}
}