using Managers.InputManager;
using System.Collections;
using Managers;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _timeBeingAStar;
    private float _previousTimeBeingAStar;

    [SerializeField]
    private Sprite _hatSprite;

    [SerializeField] private float _deathCooldown;

    [SerializeField] private float _invubrebabilityTime;

    [SerializeField]
    private GameObject _star;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private SpriteRenderer _hatRenderer;

    [SerializeField]
    private PlayerShootingController _playerShootingController;

    [SerializeField]
    private PlayerMovementController _playerMovementController;

    [SerializeField]
    private GameObject _starCollectiblePrefab;

    [SerializeField] 
    private TextMeshProUGUI _text;

    private bool _invubrebal;

    private bool _isAStar;
    private float _startTimeBeingAStar;
    private Vector3 _deathPosition;

    private Player player;

    [SerializeField]
    private ParticleSystem _sparks;

    [SerializeField]
    private ParticleSystem _respawn;

    [SerializeField]
    private ParticleSystem _starGet;

    private Collider _collider;

    private void Awake()
    {
        _hatRenderer.sprite = _hatSprite;
    }



    private void Start()
    {
        _collider = GetComponent<Collider>();
        _playerMovementController = GetComponent<PlayerMovementController>();

        transform.position = PlayerSpawningController.GetSpawningPoint(GetComponent<PlayerMovementController>().PlayerId);
    }

    public void BecameAStar()
    {
        GameManager.Instance.AudioManager.PlaySfx(1);
        var par = Instantiate(_starGet, transform.position, Quaternion.identity);

        par.transform.SetParent(transform);

        if (_isAStar)
            return;

        _isAStar = true;
        _startTimeBeingAStar = Time.realtimeSinceStartup;
        _timeBeingAStar = 0.0f;

        _player.SetActive(false);
        _star.SetActive(true);
        _playerShootingController.enabled = false;
    }

    public void StopBeingAStar()
    {
        _isAStar = false;

        _previousTimeBeingAStar += _timeBeingAStar;

        _player.SetActive(true);
        _star.SetActive(false);
        _playerShootingController.enabled = true;

    }

    private void Update()
    {
        if (_isAStar)
        {
            _timeBeingAStar = Time.realtimeSinceStartup - _startTimeBeingAStar;

            var currentTime = _timeBeingAStar + _previousTimeBeingAStar;



            _text.text = currentTime.ToString("0.00");
        }
        else
            _text.text = _previousTimeBeingAStar.ToString("0.00");
    }

    public void KillPlayer()
    {
        if(_invubrebal)
            return;

        _deathPosition = transform.position;

        Debug.Log("Kill");

        bool shouldDrop = false;

        if (_isAStar)
        {
            StopBeingAStar();
            shouldDrop = true;

        }

        Instantiate(_sparks, _deathPosition, Quaternion.identity);
        GameManager.Instance.AudioManager.PlaySfx(0);

        StartCoroutine(StartRespawn());

        if (shouldDrop)
            StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        yield return new WaitForSeconds(0.3f);

        DropCollectible();
    }

    private IEnumerator StartRespawn()
    {
        _star.SetActive(false);
        _player.SetActive(false);
        _hatRenderer.enabled = false;
        _playerShootingController.enabled = false;
        _playerMovementController.enabled = false;
        _collider.enabled = false;

         yield return new WaitForSeconds(_deathCooldown);

        _invubrebal = true;

        Respawn();

        _star.SetActive(false);
        _player.SetActive(true);
        _hatRenderer.enabled = true;
        _playerShootingController.enabled = true;
        _playerMovementController.enabled = true;
        _collider.enabled = true;

        yield return new WaitForSeconds(_invubrebabilityTime);

        _invubrebal = false;


    }

    private void Respawn()
    {
        transform.position = PlayerSpawningController.GetSpawningPoint();

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        Instantiate(_respawn, transform.position, Quaternion.identity);
    }

    private void DropCollectible()
    {
        Debug.Log("Instantiate");

        Instantiate(_starCollectiblePrefab, _deathPosition, Quaternion.identity);

        Debug.Log("Done");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Star Trigger");

        if (other.CompareTag("Star"))
        {
            BecameAStar();
            Destroy(other.transform.parent.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounding"))
        {
            Respawn();
            Debug.Log("Exit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bounding"))
        {
            Debug.Log("In bound");
        }
    }

}