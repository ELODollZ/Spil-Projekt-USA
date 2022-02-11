using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

//af Rasmus

public class WallPing : MonoBehaviour, IHitObj
{
    [SerializeField]
    float dampening;

    public float Dampening { get { return dampening; } }

    List<Vector2> hitpoints =  new List<Vector2>(10);
    int count = 0;

    List<Vector2> toShow = new List<Vector2>(500);

    bool pinged = false;

    public GameObject getOriginObj()
    {
        return gameObject;
    }

    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft)
    {
        hitpoints.Add(hitPoint);
    }

    //når vægen bliver pinget
    public void Ping()
    {
        toShow.AddRange(hitpoints);
        hitpoints.Clear();
        pinged = true;
    }

    private void Update()
    {
        if (pinged)
        {
            for (int i = 0; i < toShow.Count; i++)
            {
                GameObject obj = Pooler.poolerSingelton.GetObj(0);
                PingedTimedDisapering pingedTimed = obj.GetComponent<PingedTimedDisapering>();
                pingedTimed.PoolInstantiate(toShow[i], new Vector3());
            }
            pinged = false;
            toShow.Clear();
        }
    }

    public void EndOfRay()
    {
        hitpoints.Clear();
    }
}
