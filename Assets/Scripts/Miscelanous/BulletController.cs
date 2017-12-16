using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 20f;

    private Vector3 _bulletDirection;

    public void SetBulletDirection(Vector3 dir)
    {
        _bulletDirection = dir;
    }

    private void Update()
    {
        transform.Translate(_bulletDirection.x / _bulletDirection.magnitude * _speed * Time.deltaTime, 0, _bulletDirection.z / _bulletDirection.magnitude * _speed * Time.deltaTime);
    }
}