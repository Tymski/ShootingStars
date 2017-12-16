using Managers;
using Managers.InputManager;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private int _playerId;

    [SerializeField]
    private float _speed;

    private  CharacterController _characterController;

    private Vector3 _moveDirection;

    private float _direction;

    private Player _player;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
    }

    public Player Player
    {
        get { return _player; }
    }

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _player = GameManager.Instance.InputManager.GetPlayer(_playerId);
    }

    void Update()
    {
        _moveDirection = new Vector3(_player.GetAxis(PlayerAxis.HORIZONTAL), 0, _player.GetAxis(PlayerAxis.VERTICAL));

        _moveDirection = new Vector3(_moveDirection.x / _moveDirection.magnitude, 0, _moveDirection.z / _moveDirection.magnitude);

        _moveDirection *= _speed;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
