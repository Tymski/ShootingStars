using UnityEngine;

public class KillPlayersByExplosion : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
        else return;
    }
}