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
        transform.Translate(BulletDirection.x / BulletDirection.magnitude * Speed * Time.deltaTime, 0, BulletDirection.z / BulletDirection.magnitude * Speed * Time.deltaTime);
    }
}