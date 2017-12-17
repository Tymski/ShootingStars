using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    public GameObject ThisPlayer;
    public float DestroyTime = 10f;

    public ParticleSystem _hit;

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
        if (other.CompareTag("Player"))
        {
            if(other.gameObject == ThisPlayer)
                return;

            other.GetComponent<PlayerController>().KillPlayer();

            

            Destroy();
        }
        var particle = Instantiate(_hit, transform.position, Quaternion.identity);

        Debug.Log(particle);

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
