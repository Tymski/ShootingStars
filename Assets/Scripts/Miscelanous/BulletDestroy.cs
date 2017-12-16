using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    public float DestroyTime = 10f;

    void OnEnable()
    {
        Invoke("Destroy", DestroyTime);
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
