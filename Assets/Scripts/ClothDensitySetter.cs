using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ClothDensitySetter : MonoBehaviour
{
    MeshCreator.Settings _settings;

    [Inject]
    public void Construct(MeshCreator.Settings settings)
    {
        _settings = settings;

    }


    public void SetDensity(PlanePiece piece) {
        StartCoroutine(SetDensityCoroutine(piece));
    }

    IEnumerator SetDensityCoroutine(PlanePiece piece)
	{
        yield return null;
        ClothSkinningCoefficient[] newConstraints;
        newConstraints = piece.Cloth.coefficients;

        for (int i = 0; i < newConstraints.Length; i++) {
            newConstraints[i].maxDistance = i % ((int)_settings.planeWidth + 1);
        }

        piece.Cloth.coefficients = newConstraints;

    }

}
