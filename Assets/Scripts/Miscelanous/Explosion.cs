using UnityEngine;

public class Explosion : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().KillPlayer();
    }
}
