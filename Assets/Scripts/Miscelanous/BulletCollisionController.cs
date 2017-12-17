using System.Collections;
using Managers;
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
        GameManager.Instance.AudioManager.PlaySfx(2);

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

        if (other.CompareTag("Barell"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 2f);
        }

        if (!other.CompareTag("Bounding"))
        {
            var particle = Instantiate(_hit, transform.position, Quaternion.identity);

            Debug.Log(particle);

            gameObject.SetActive(false);
        }
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
