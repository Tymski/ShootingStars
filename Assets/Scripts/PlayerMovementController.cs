﻿using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
    public float Speed;
    public CharacterController CharacterController;
    private Vector3 _moveDirection = Vector3.zero;

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection *= Speed;
        CharacterController.Move(_moveDirection * Time.deltaTime);
    }
}
