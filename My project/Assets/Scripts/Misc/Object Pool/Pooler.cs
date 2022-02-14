using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc.Pool;
//af Rasmus

    //En object pooler for optimisering

public class Pooler : MonoBehaviour
{
    [SerializeField]
    poolObj[] poolObject;

    Pool<GameObject>[] pools;

    public static Pooler poolerSingelton;

    private void Awake()
    {
        if (poolerSingelton == null)
        {
            poolerSingelton = this;
        }
        else
        {
            Destroy(this);
        }
    }


    void Start()
    {
        //Spawner alle de pools der er sat op
        pools = new Pool<GameObject>[poolObject.Length];
        for (int i = 0; i < poolObject.Length; i++)
        {
            pools[i] = new Pool<GameObject>(0);
            GameObject[] objects = new GameObject[poolObject[i].amt];
            for (int j = 0; j < objects.Length; j++)
            {
                GameObject obj = Instantiate(poolObject[i].poolObject, transform);
                obj.SetActive(false);
                objects[j] = obj;
            }
            pools[i].SetPool(objects);
        }
    }

    //Giver det næste pool obj ud fra en string navn på pool
    public GameObject GetObj(string poolName)
    {
        int poolIndex = -1;
        for (int i = 0; i < poolObject.Length; i++)
        {
            if (poolObject[i].poolName == poolName)
            {
                poolIndex = i;
            }
        }

        return pools[poolIndex].GetNext();
    }
    //Giver det næste pool obj ud fra et ID af pool
    public GameObject GetObj(int poolID)
    {
        int poolIndex = -1;
        for (int i = 0; i < poolObject.Length; i++)
        {
            if (poolObject[i].poolID == poolID)
            {
                poolIndex = i;
            }
        }

        return pools[poolIndex].GetNext();
    }

    // en struktur til opsætning af pools
    [System.Serializable]
    public struct poolObj
    {
        public GameObject poolObject;
        public int amt;
        public int poolID;
        public string poolName;
    }
}


