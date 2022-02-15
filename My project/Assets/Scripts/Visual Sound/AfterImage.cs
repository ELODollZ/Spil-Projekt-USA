using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    SpriteRenderer spriteRendererOfObj;

    [SerializeField]
    SpriteRenderer rendererOfAfterImage;

    [SerializeField]
    float afterImageTime = 1.5f;

    float imageTime;
    float imageTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererOfObj = GetComponent<SpriteRenderer>();
        rendererOfAfterImage.transform.parent = null;
    }

    public void CreateAfterImage(float power)
    {
        rendererOfAfterImage.sprite = spriteRendererOfObj.sprite;
        rendererOfAfterImage.transform.position = transform.position;
        rendererOfAfterImage.flipX = spriteRendererOfObj.flipX;
        imageTime = afterImageTime * power;
        imageTimeLeft = imageTime;
    }

    private void Update()
    {
        if (imageTimeLeft > 0)
        {
            imageTimeLeft -= Time.deltaTime;
            if (imageTimeLeft < 0) imageTimeLeft = 0;
            rendererOfAfterImage.color = new Color(rendererOfAfterImage.color.r, rendererOfAfterImage.color.g, rendererOfAfterImage.color.b, imageTimeLeft/ imageTime);
        }
    }
}
