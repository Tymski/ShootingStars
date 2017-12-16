using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 3f;
    private Vector3 BulletDirection;

    public void SetBulletDirection(Vector3 dir)
    {
        BulletDirection = dir;
    }
    void Update()
    {
        transform.Translate(BulletDirection.x * Speed * Time.deltaTime, 0, BulletDirection.z * Speed * Time.deltaTime);
    }
}