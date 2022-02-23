using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;
using UnityEngine.Events;

//af Rasmus

public class EnemyAI : MonoBehaviour, IHitObj
{
    [SerializeField] AIState aIState = null;

    [SerializeField] float soundDampening = 1;

    [SerializeField] UnityEvent HitPing;

    [SerializeField]
    UnityEvent scream;

    public float Dampening { get { return soundDampening; } }

    public Vector2 HitPos {get { return transform.position; } }

    //info fra h�jest lyd
    private ISoundOrigin soundOrigin;
    private Vector2 soundPoint;
    private float disLeft;

    bool wasHit = false;

    [SerializeField] UnityEvent OnBonk;

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
        AIState prevState = aIState;

        if (wasHit)
        {
            aIState = aIState.HandleSoundHit(soundOrigin, soundPoint, disLeft);
            disLeft = -1;
            wasHit = false;
        }

        aIState = aIState.UpdateState(Time.deltaTime);
        if (prevState != aIState)
        {
            scream?.Invoke();
        }
    }

    //n�r mosteret h�re en lyd
    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, float fullDis)
    {
        wasHit = true;
        if (this.disLeft < disLeft)
        {
            soundOrigin = origin;
            this.disLeft = disLeft;
            //finder det punkt hvor fra lyden blev h�rt fra, det f�rste
            if (hits[1] == null) soundPoint = origin.SoundPos;
            else
            {
                for (int i = 2; i < hits.Length; i++)
                {
                    if (hits[i] == null)
                    {
                        soundPoint = hits[i-2].HitPos;
                        break;
                    }
                }
            }
        }
    }

    public void EndOfRay()
    {
    }
    public void Ping()
    {
        HitPing?.Invoke();
    }

    //hvis monstert rammer noget
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // g�r dr�b spiller ting her
        }
        else
        {
            OnBonk?.Invoke();
        }
    }
}


public abstract class AIState : MonoBehaviour
{
    public abstract AIState UpdateState(float deltaTime);
    public abstract AIState HandleSoundHit(ISoundOrigin origin,Vector2 point, float disLeft);
}
