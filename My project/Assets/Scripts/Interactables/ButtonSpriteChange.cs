using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteChange : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    int spriteNext = 0;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = sprites[spriteNext];
        spriteNext++;
        if (spriteNext == sprites.Length)
        {
            spriteNext = 0;
        }
    }

}
