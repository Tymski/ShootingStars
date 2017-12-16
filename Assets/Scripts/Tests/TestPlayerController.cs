using System.Collections;
using System.Collections.Generic;
using Managers;
using Managers.InputManager;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    public int PlayerId;

    private Player _player;

    private SpriteRenderer _spriteRenderer;

    private Transform _transform;

    private float _horizontal, _vertical;

    public void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        _player = GameManager.Instance.InputManager.GetPlayer(PlayerId);
    }

    public void Update()
    {
        _horizontal = _player.GetAxis(PlayerAxis.HORIZONTAL);
        _vertical = _player.GetAxis(PlayerAxis.VERTICAL);

        Debug.Log("A: " + _player.GetButtonDown(PlayerButton.A) + "B: " + _player.GetButtonDown(PlayerButton.B) + "Y: " + _player.GetButtonDown(PlayerButton.Y) + "X: " + _player.GetButtonDown(PlayerButton.X));
    }

    private void FixedUpdate()
    {
        _transform.position = new Vector3(_transform.position.x + _horizontal * 3f * Time.fixedDeltaTime,
            _transform.position.y + _vertical * 3f * Time.fixedDeltaTime, _transform.position.z);
    }

}
