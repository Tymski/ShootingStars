using UnityEngine;
using System.Collections.Generic;
using GamepadInput;

public class PlayerShootingController : MonoBehaviour
{
    public Vector3 LastVector3 = new Vector3(1,0,0);
    void Update()
    {
        Vector3 tmpVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (tmpVector.magnitude > 0) LastVector3 = tmpVector;
        {
            if (Input.GetKeyDown("r"))
            {
                GameObject obj = CreateObjectPoolingController.current.GetPooledObject();
                if (obj == null)
                {
                    Debug.Log("There is no object");
                }
                obj.GetComponent<BulletScript>().SetBulletDirection(LastVector3);
                obj.GetComponent<BulletDestroy>().SetPlayer(this.gameObject);
                obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                obj.SetActive(true);
            }
        }
    }
}
