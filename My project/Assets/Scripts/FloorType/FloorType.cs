using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Rasmus

public class FloorType : MonoBehaviour
{
    private void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D.size = spriteRenderer.size;
    }

    public FloorTypes floorType = FloorTypes.wood;
}

public enum FloorTypes
{
    wood,
    stone,
    metal,
    carpet
}