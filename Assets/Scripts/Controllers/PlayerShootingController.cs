using UnityEngine;
using System.Collections.Generic;
using GamepadInput;
using Managers.InputManager;

public class PlayerShootingController : MonoBehaviour
{
    private Vector3 _lastVector3 = new Vector3(1,0,0);

    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        Vector3 tmpVector = _playerMovementController.MoveDirection;

        if (tmpVector.magnitude > 0) _lastVector3 = tmpVector;
        {
            if (_playerMovementController.Player.GetButtonDown(PlayerButton.A))
            {
                GameObject obj = CreateObjectPoolingController.current.GetPooledObject();

                if (obj == null)
                    throw new UnityException("Pooler is empty!");

                obj.GetComponent<BulletController>().SetBulletDirection(_lastVector3);
                obj.GetComponent<BulletCollisionController>().SetPlayer(this.gameObject);
                obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                obj.SetActive(true);
            }
        }
    }
}
