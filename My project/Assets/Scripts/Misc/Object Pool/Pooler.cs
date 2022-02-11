using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc.Pool;
//af Rasmus

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
        pools = new Pool<GameObject>[poolObject.Length];

        for (int i = 0; i < poolObject.Length; i++)
        {
            pools[i] = new Pool<GameObject>(0);
            GameObject[] objects = new GameObject[poolObject[i].amt];
            for (int j = 0; j < objects.Length; j++)
            {
                GameObject obj = Instantiate(poolObject[i].poolObject);
                obj.SetActive(false);
                objects[j] = obj;
            }
            pools[i].SetPool(objects);
        }
    }


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

    [System.Serializable]
    public struct poolObj
    {
        public GameObject poolObject;
        public int amt;
        public int poolID;
        public string poolName;
    }



}


