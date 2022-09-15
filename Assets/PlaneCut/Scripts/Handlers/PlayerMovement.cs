using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;
using Zenject;

namespace PlaneCut
{
	public class PlayerMovement : MonoBehaviour
	{
		private Sequence _sequence;
		private GameObject _goToLookAt;
		private ILineConstructable _lineConstruct;
		private SignalBus _signalBus;

		[Inject]
		public void Construct(ILineConstructable lineConstruct, Settings settings, SignalBus signalBus)
		{
			_signalBus = signalBus;
			_lineConstruct = lineConstruct;

			if (_sequence != null) {
				_sequence.Kill();
				Destroy(_goToLookAt);
			}
			var waypoints = _lineConstruct.Points.Select(p => new Vector3(p.x, p.y, 0)).ToArray();

			_sequence = DOTween.Sequence();

			_goToLookAt = new GameObject("goToLookAt");
			_goToLookAt.transform.parent = transform.parent;
			_goToLookAt.transform.position = transform.position;

			_sequence.Append(transform.DOLocalPath(waypoints, settings.tripTime));
			_sequence.Play();
			_goToLookAt.transform.DOLocalPath(waypoints, settings.tripTime * 0.9f);
			_sequence.onUpdate += UpdateRotation;
			_sequence.onComplete += OnCompletePath;

		}

		void OnCompletePath()
		{
			_signalBus.Fire<FinishedPlayerSignal>();
		}

		void UpdateRotation()
		{
			if (_goToLookAt != null)
				transform.LookAt(_goToLookAt.transform);
		}

		[Serializable]
		public class Settings
		{
			[Range(3, 20)]
			public float tripTime = 15f;
		}
	}
}