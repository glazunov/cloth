using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneCut
{
	public interface IMeshCreatable
	{
		Dictionary<PieceSide, Mesh> Meshes { get; }
	}
}

