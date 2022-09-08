using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class CameraInitializer : MonoBehaviour
{
	[SerializeField]
	private Cinemachine.CinemachineVirtualCamera camera;

    [Inject]
    void Construct(PlayerMovement movement)
	{
		camera.m_LookAt = movement.transform;
		camera.m_Follow = movement.transform;
	}
}
