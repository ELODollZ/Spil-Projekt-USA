using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundWaveSystem;

//af Rasmus

public class WallPing : MonoBehaviour, IHitObj
{
    [SerializeField]
    float dampening, optimizeDis = 0.1f;

    public float Dampening { get { return dampening; } }

    List<Vector2> hitpoints =  new List<Vector2>(10);

    List<Vector2> toShow = new List<Vector2>(500);

    bool pinged = false;

    List<PingedTimedDisapering> activePoolItems = new List<PingedTimedDisapering>(1300);

    public void Hit(ISoundOrigin origin, IHitObj[] hits, Vector2 hitPoint, float disLeft, AudioClip audioClip)
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
            SpawnPingShower();
        }
    }

    //Spawner de steder der blev pinget
    private void SpawnPingShower()
    {
        OptimizePreSpawns();
        for (int i = 0; i < toShow.Count; i++)
        {
            if (!OptimizeAfterSpawn(toShow[i]))
            {
                GameObject obj = Pooler.poolerSingelton.GetObj(0);
                PingedTimedDisapering pingedTimed = obj.GetComponent<PingedTimedDisapering>();
                pingedTimed.disabledEvent += PingEnded;
                activePoolItems.Add(pingedTimed);
                pingedTimed.PoolInstantiate(toShow[i], new Vector3());
            }
        }
        pinged = false;
        toShow.Clear();
    }


    //Fjerner pings der var tæt på hinanden for at optimisere
    private void OptimizePreSpawns()
    {
        for (int i = 0; i < toShow.Count; i++)
        {
            for (int j = i+1; j < toShow.Count; j++)
            {
                if (Vector2.Distance(toShow[i], toShow[j]) <= optimizeDis)
                {
                    toShow.RemoveAt(j);
                    j--;
                }
            }
        }
    }

    //Lader vær med at fjerne gamle pings hvis der er en ny ping der gærne vil spawne der
    private bool OptimizeAfterSpawn(Vector2 pos)
    {
        for (int i = 0; i < activePoolItems.Count; i++)
        {
            if (activePoolItems[i] == null) return false;

            if (Vector2.Distance( activePoolItems[i].transform.position, pos) <= optimizeDis)
            {
                activePoolItems[i].RestartTimer();
                return true;
            }
        }
        return false;
    }

    private void PingEnded(PingedTimedDisapering obj)
    {
        obj.disabledEvent -= PingEnded;
        activePoolItems.Remove(obj);
    }


    public void EndOfRay()
    {
        hitpoints.Clear();
    }
}
