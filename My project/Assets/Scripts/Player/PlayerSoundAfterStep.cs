using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//af Rasmus
    // et simpelt scrip der laver en event efet en vis distance er gået
public class PlayerSoundAfterStep : MonoBehaviour
{
    [SerializeField]
    float disBetweenStep;

    float disToNextStep;

    Vector2 lastPos;

    [SerializeField]
    UnityEvent step;


    private void Start()
    {
        disToNextStep = 0.01f;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        disToNextStep -= Vector2.Distance(lastPos, (Vector2)transform.position);
        lastPos = transform.position;

        if (disToNextStep <= 0)
        {
            disToNextStep = disBetweenStep;
            step?.Invoke();
        }
    }
}
