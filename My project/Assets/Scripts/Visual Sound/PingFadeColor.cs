using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Rasmus
//et script der står for at fade alphaen af en sprite så den langsomt forsvinder

public class PingFadeColor : MonoBehaviour
{
    SpriteRenderer spriteRendererOfObj;

    [SerializeField]
    float fadeTime = 1.5f;

    float imageTime;
    float imageTimeLeft;



    // Start is called before the first frame update
    void Start()
    {
        spriteRendererOfObj = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (imageTimeLeft > 0)
        {
            imageTimeLeft -= Time.deltaTime;
            if (imageTimeLeft < 0) imageTimeLeft = 0;
            spriteRendererOfObj.color = new Color(spriteRendererOfObj.color.r, spriteRendererOfObj.color.g, spriteRendererOfObj.color.b, imageTimeLeft / imageTime);
        }
    }

    //starter fade
    public void StartFadeOfColor(float power)
    {
        imageTime = fadeTime * power;
        imageTimeLeft = imageTime;
    }
}
