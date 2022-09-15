using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlaneCut
{
	public enum PieceSide
	{
		Left,
		Right
	}

	public class PlanePiece : MonoBehaviour
	{
		public Cloth Cloth { get => _cloth; }
		public MeshFilter MeshFilter { get => _meshFilter; }
		public PieceSide Side { get => _side; }

		[SerializeField]
		private Cloth _cloth;

		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private SkinnedMeshRenderer _skinnedMeshRenderer;

		private PieceSide _side;

		private ClothDensitySetter _clothDensitySetter;
		private DistanceSetter _distanceSetter;


		[Inject]
		public void Construct(ClothDensitySetter clothDensitySetter,
			PieceSide side, DistanceSetter distanceSetter, Mesh mesh)
		{
			_side = side;

			_meshFilter.mesh = mesh;
			_skinnedMeshRenderer.sharedMesh = _meshFilter.mesh;

			_clothDensitySetter = clothDensitySetter;
			_clothDensitySetter.SetDensity(this);
			_distanceSetter = distanceSetter;
			distanceSetter.SetPosition(this);
		}

		public class Factory : PlaceholderFactory<PieceSide, Mesh, PlanePiece>
		{
		}

	}
}