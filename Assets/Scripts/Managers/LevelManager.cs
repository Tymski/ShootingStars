using UnityEngine;

namespace Managers
{

    public class LevelManager : MonoBehaviour
    {
        private float _levelStartTime;

        [SerializeField]
        private float _levelTime;

        [SerializeField]
        private float _startTime;

        private float _currentTime;

        public string LevelName;

        private bool _levelStarted;
        private bool _levelFinished;

        private void Awake()
        {
            Debug.Log("Start");
            _levelStartTime = Time.realtimeSinceStartup;
        }

        private void Update()
        {
            _currentTime = Time.realtimeSinceStartup - _levelStartTime;

            if (!_levelStarted && _currentTime > _startTime)
            {
                Debug.Log("Play");
                _levelStarted = true;
            }

            if (_levelStarted && !_levelFinished && _currentTime > _levelTime + _startTime)
            {
                _levelFinished = true;
                Finish();
            }
        }

        private void Finish()
        {
            Debug.Log("Finish");
        }
    }
    

}
