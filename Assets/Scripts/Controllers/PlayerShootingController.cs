using UnityEngine;
using System.Collections.Generic;
using GamepadInput;

public class PlayerShootingController : MonoBehaviour
{

    void Update()
    {
        {
            if (Input.GetKeyDown("r"))
            {
                GameObject obj = CreateObjectPoolingController.current.GetPooledObject();
                if (obj == null)
                {
                    Debug.Log("There is no object");
                }
                obj.GetComponent<BulletScript>().SetBulletDirection(new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")));
                obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                //obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
            }
        }
    }
}
