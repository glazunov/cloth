using System.Collections.Generic;
using UnityEngine;

namespace PlaneCut {
	public interface ILineConstructable
	{
		List<Vector2> Points { get;	}
	}
}
