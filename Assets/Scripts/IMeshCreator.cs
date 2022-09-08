using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMeshCreatable 
{
    Dictionary<PieceSide, Mesh> Meshes { get; }
}


