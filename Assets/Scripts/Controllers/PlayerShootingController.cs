using UnityEngine;
using System.Collections.Generic;

public class PlayerShootingController : MonoBehaviour
{

    public float FireTime = 0.5f;
    public GameObject Bullet;

    public int pooledAmount = 20;
    private List<GameObject> _bullets;
    

	void Start () {
		_bullets = new List<GameObject>();
	    for (int i = 0; i < pooledAmount; i++)
	    {
	        GameObject obj = (GameObject) Instantiate(Bullet);
	        obj.SetActive(false);
            _bullets.Add(obj);
	    }

        InvokeRepeating("Fire", FireTime, FireTime);
	}
	
	void Fire ()
	{
	    for (int i = 0; i < _bullets.Count; i++)
	    {
	        if (!_bullets[i].activeInHierarchy)
	        {
	            _bullets[i].transform.position = transform.position;
	            _bullets[i].transform.rotation = transform.rotation;
	            _bullets[i].SetActive(true);
	            break;
	        }
	    }
	}
}
