using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlaneCut
{
	public class LineConstructer : ILineConstructable
	{
		List<Vector2> _points;
		public List<Vector2> Points { get => _points; private set => _points = value; }

		[Inject]
		public LineConstructer(Settings s)
		{
			_points = ConstructLine(s.minAngle, s.maxAngle, s.minLength, s.maxLength, Vector3.zero, Vector2.up * s.minimalPlaneHeight, new List<Vector2>());
		}

		List<Vector2> ConstructLine(float minAngle, float maxAngle, float minLength, float maxLength, Vector2 startPoint, Vector2 minHeight, List<Vector2> points)
		{
			if (points.Count == 0) {
				points.Add(Vector2.zero);
				return ConstructLine(minAngle, maxAngle, minLength, maxLength, startPoint, minHeight, points);
			}

			var angle = Mathf.Deg2Rad * UnityEngine.Random.Range(minAngle, maxAngle);
			var length = UnityEngine.Random.Range(minLength, maxLength);
			Vector2 delta = new Vector2(Mathf.Sin(angle) * length, Mathf.Cos(angle) * length);
			Vector2 newPoint = points[points.Count - 1] + delta;

			points.Add(newPoint);

			if (newPoint.y > minHeight.y || points.Count > 1000) {
				return points;
			}

			return ConstructLine(minAngle, maxAngle, minLength, maxLength, startPoint, minHeight, points);
		}

		[Serializable]
		public class Settings
		{
			[Range(-35f, 0)]
			public float minAngle = -35f;
			[Range(0, 35)]
			public float maxAngle = 35f;

			[Space]

			[Range(0.05f, 0.5f)]
			public float minLength;
			[Range(0.5f, 1.5f)]
			public float maxLength;

			[Space]

			[Range(10f, 15f)]
			public float minimalPlaneHeight = 10;
		}
	}
}