using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace PlaneCut
{
	public class MeshCreator : IMeshCreatable
	{
		public Dictionary<PieceSide, Mesh> Meshes { get => _meshes; }
		private Dictionary<PieceSide, Mesh> _meshes = new Dictionary<PieceSide, Mesh>();

		[Inject]
		public MeshCreator(Settings settings, ILineConstructable lineConstructer)
		{
			_meshes.Add(PieceSide.Left, Generate((int)settings.planeWidth, lineConstructer.Points, true));
			_meshes.Add(PieceSide.Right, Generate((int)settings.planeWidth, lineConstructer.Points, false));
		}

		Mesh Generate(int xSize, List<Vector2> points, bool leftSide)
		{
			var mesh = new Mesh();
			Vector3[] vertices;
			var ySize = points.Count;

			mesh.name = "Procedural Grid";

			vertices = new Vector3[(xSize + 1) * (ySize + 1)];

			Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

			int dir = leftSide ? -1 : 1;
			int a = 0;
			var planeHeight = points.OrderByDescending(p => p.y).FirstOrDefault().y;

			for (int i = 0, y = 0; y <= ySize; y++) {
				for (int x = 0; x <= xSize; x++, i++) {
					var resultX = dir * x;
					var resultY = Mathf.Clamp(y, 0, planeHeight);

					vertices[i] = new Vector3(resultX, resultY);

					if (x == 0 && a < points.Count) {
						vertices[i] = points[a] - new Vector2(3, 0) * dir;
						a++;
					}
				}
			}

			for (int i = 0; i < vertices.Length; i++) {
				vertices[i] = vertices[i] + new Vector3(3, 0, 0) * dir;

			}
			mesh.vertices = vertices;

			int[] triangles = new int[xSize * ySize * 6];
			for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
				for (int x = 0; x < xSize; x++, ti += 6, vi++) {
					triangles[ti] = vi;
					triangles[ti + 3] = triangles[ti + 2] = vi + 1;
					triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
					triangles[ti + 5] = vi + xSize + 2;
				}
			}
			mesh.triangles = triangles;
			mesh.RecalculateNormals();

			return mesh;
		}

		[Serializable]
		public class Settings
		{
			[Range(5, 15)]
			public float planeWidth;
		}
	}
}