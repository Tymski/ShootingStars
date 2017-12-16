using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    public float DestroyTime = 10f;

    void OnEnable()
    {
        Invoke("Destroy", DestroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        gameObject.SetActive(false);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
