using System.Collections;
using System.Collections.Generic;
using Managers;
using Managers.InputManager;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    public int PlayerId;

    public GameObject BulletPrefab;

    public float Speed;

    private Player _player;

    private SpriteRenderer _spriteRenderer;

    private Transform _transform;

    private Transform _spriteTransform;

    private float _horizontal, _vertical;

    public void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _spriteTransform = _spriteRenderer.transform;
    }

    public void Start()
    {
        _player = GameManager.Instance.InputManager.GetPlayer(PlayerId);
    }

    public void Update()
    {
        _spriteTransform.LookAt(_spriteTransform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    
        _horizontal = _player.GetAxis(PlayerAxis.HORIZONTAL);
        _vertical = _player.GetAxis(PlayerAxis.VERTICAL);

        if(_player.GetButtonDown(PlayerButton.A))
            Shoot();
        
    }

    private void FixedUpdate()
    {
        _transform.position = new Vector3(_transform.position.x + _horizontal * Speed * Time.fixedDeltaTime,
            _transform.position.y , _transform.position.z + _vertical * Speed * Time.fixedDeltaTime);
    }

    public void Shoot()
    {
        var shootVector = new Vector3(_horizontal, 0, _vertical);

        Debug.Log(shootVector);

        

        var bullet = Instantiate(BulletPrefab, _transform.position, Quaternion.identity);
    
        bullet.GetComponent<TestBullet>().Set(shootVector);
    }
}
