using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody _rigidbody;

    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Set(Vector3 velocity)
    {
        _rigidbody.velocity = velocity * _speed;
    }

}