using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
// s�re for at alle pool objekter har en Instantiate funktion der fungere p� nogenlunde samme m�de som den normale Instantiate funktion i Unity

public interface IPoolerble
{
    GameObject PoolInstantiate(Vector2 pos, Vector3 rot);
}

