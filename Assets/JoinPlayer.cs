using Managers.InputManager;
using UnityEngine;

public class JoinPlayer : MonoBehaviour {

    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        //        if (_playerMovementController.Player.GetButtonDown(PlayerButton.A))
        if (Input.GetButtonDown("q"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
