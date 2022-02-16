using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//af rasmus
// søre for at alle pool objekter har en Instantiate funktion der fungere på nogenlunde samme måde som den normale Instantiate funktion i Unity

public interface IPoolerble
{
    GameObject PoolInstantiate(Vector2 pos, Vector3 rot);
}

