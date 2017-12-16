using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _timeBeingAStar;
    private float _previousTimeBeingAStar;


    [SerializeField]
    private GameObject _star;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private SpriteRenderer _hatRenderer;


    private bool _isAStar;
    private float _startTimeBeingAStar;


    public void BecameAStar()
    {
        _isAStar = true;
        _startTimeBeingAStar = Time.realtimeSinceStartup;
        _previousTimeBeingAStar = _timeBeingAStar;
        _timeBeingAStar = 0.0f;
    }


    private void Update()
    {
        if (_isAStar)
        {
            
        }
    }
}