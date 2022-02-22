using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaleCollider : MonoBehaviour
{
    private void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D.size = spriteRenderer.size;
    }
}
