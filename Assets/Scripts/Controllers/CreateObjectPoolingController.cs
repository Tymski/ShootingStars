using UnityEngine;
using System.Collections.Generic;

public class CreateObjectPoolingController : MonoBehaviour
{
    public static CreateObjectPoolingController current;
    public GameObject pooledObject;
    public int pooledAmount = 14;
    public bool willGrow = true;

    List<GameObject> pooledObjects;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
       
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = (GameObject)Instantiate(pooledObject);

        Destroy(obj, 10.0f);

        return obj;

       
    }
}
