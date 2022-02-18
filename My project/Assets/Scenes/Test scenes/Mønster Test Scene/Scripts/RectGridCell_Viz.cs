using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectGridCell_Viz : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer InnerSprite;
    [SerializeField]
    SpriteRenderer OuterSprite;

    public RectGridCell RectGridCell;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInnerColor(Color col)
    {
        InnerSprite.color = col;
    }

    public void SetOuterColor(Color col)
    {
        OuterSprite.color = col;

    }



}
