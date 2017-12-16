using UnityEngine;

public class BulletCollisionController : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            if(other.gameObject == ThisPlayer)
                return;

            other.gameObject.SetActive(false);
            KillPlayer();
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

    void KillPlayer()
    {
        gameObject.SetActive(false);
    }
}
