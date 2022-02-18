using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorType : MonoBehaviour
{
    public FloorTypes floorType = FloorTypes.wood;
}

public enum FloorTypes
{
    wood,
    stone,
    metal,
    carpet
}