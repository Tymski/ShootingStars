using Managers;
using Managers.InputManager;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    public int PlayerId;

    [SerializeField]
    private float _speed;

    //private  CharacterController _characterController;

    private Rigidbody _rigidbody;

    private Vector3 _moveDirection;

    private float _direction;

    private Player _player;

    [SerializeField]
    private SpriteRenderer _starRenderer;

    [SerializeField]
    private SpriteRenderer _playerRenderer;


    private Animator _animator;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
    }

    public Player Player
    {
        get { return _player; }
    }

    private void UpdateAnimator()
    {
        _animator.SetBool("isWalking", _moveDirection.x != 0 || _moveDirection.z != 0);

        _playerRenderer.flipX = false;
        _starRenderer.flipX = false;

        if (_moveDirection.z > 0)
        {
            _animator.SetBool("side", false);
            _animator.SetBool("up", true);
            _animator.SetBool("down", false);
        }
        else if (_moveDirection.z < 0)
        {
            _animator.SetBool("side", false);
            _animator.SetBool("up", false);
            _animator.SetBool("down", true);
        }
        else if (_moveDirection.x > 0 || _moveDirection.x < 0)
        {
            if (_moveDirection.x < 0)
            {
                _playerRenderer.flipX = true;
                _starRenderer.flipX = true;
            }

            _animator.SetBool("side", true);
             _animator.SetBool("up", false);
             _animator.SetBool("down", false);
        }
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _player = GameManager.Instance.InputManager.GetPlayer(PlayerId);
    }

    void Update()
    {
        _moveDirection = new Vector3(_player.GetAxis(PlayerAxis.HORIZONTAL), 0, _player.GetAxis(PlayerAxis.VERTICAL));

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        _rigidbody.position = new Vector3(_rigidbody.position.x + _moveDirection.x * _speed * Time.deltaTime,
            _rigidbody.position.y, _rigidbody.position.z + _moveDirection.z * _speed * Time.deltaTime);
    }

}
