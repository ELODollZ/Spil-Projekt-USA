using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

public class EnemyAI : MonoBehaviour, IHitObj
{
    [SerializeField] AIState aIState = null;

    [SerializeField] float soundDampening = 1;

    public float Dampening { get { return soundDampening; } }

    public Vector2 HitPos {get { return transform.position; } }

    //info fra højest lyd
    private ISoundOrigin soundOrigin;
    private IHitObj[] hits;
    private float disLeft;

    bool wasHit = false;

    void Start()
    {
        if (aIState == null)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wasHit)
        {
            aIState = aIState.HandleSoundHit(soundOrigin, hits, disLeft);
            disLeft = -1;
        }

        aIState = aIState.UpdateState(Time.deltaTime);
    }

    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, float fullDis)
    {
        wasHit = true;
        if (this.disLeft < disLeft)
        {
            soundOrigin = origin;
            this.hits = hits;
            this.disLeft = disLeft;
        }
    }

    public void EndOfRay()
    {
        throw new System.NotImplementedException();
    }
    public void Ping()
    {
        throw new System.NotImplementedException();
    }
}


public abstract class AIState : MonoBehaviour
{
    public abstract AIState UpdateState(float deltaTime);
    public abstract AIState HandleSoundHit(ISoundOrigin origin, IHitObj[] hits, float disLeft);
}
