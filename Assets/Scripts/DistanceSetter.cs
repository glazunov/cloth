using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class DistanceSetter
{
    [Inject]
    Settings _settings;

    public void SetPosition(PlanePiece planePiece)
	{
        var dir = planePiece.Side == PieceSide.Left ? -1 : 1;
           
        planePiece.transform.position =
            planePiece.transform.right
            * _settings.distanceBetweenPieces/2
            *dir;
	}

    [Serializable]
    public class Settings{
        [Range(0, 5)]
        public float distanceBetweenPieces; 
    }


}
