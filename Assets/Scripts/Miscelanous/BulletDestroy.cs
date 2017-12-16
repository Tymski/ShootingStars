using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public GameObject ThisPlayer;
    public float DestroyTime = 10f;

    public void SetPlayer(GameObject thisPlayer)
    {
        ThisPlayer = thisPlayer;
    }

    void OnEnable()
    {
        Invoke("Destroy", DestroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player") && other.gameObject == ThisPlayer)
        {
            Debug.Log("To ten gracz");
            return;
        }
  
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
