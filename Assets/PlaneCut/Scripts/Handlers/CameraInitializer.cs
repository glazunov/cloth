using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PlaneCut
{
	public class CameraInitializer : MonoBehaviour
	{
		[SerializeField]
		private Cinemachine.CinemachineVirtualCamera _camera;

		[Inject]
		void Construct(PlayerMovement movement)
		{
			_camera.m_LookAt = movement.transform;
			_camera.m_Follow = movement.transform;
		}
	}
}