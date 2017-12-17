using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        public string NextLevelName;

        private bool _levelStarted;
        private bool _levelFinished;

        [SerializeField]
        private PlayerController[] _players;

        [SerializeField]
        private TextMeshProUGUI _textMeshPro;

        [SerializeField]
        private TextMeshProUGUI _textMeshPro2;
        
        private void Awake()
        {
            Debug.Log("Start");
            _levelStartTime = Time.realtimeSinceStartup;
            _textMeshPro2.enabled = false;
            GameManager.Pause = true;
        }

        private void Update()
        {
            _currentTime = Time.realtimeSinceStartup - _levelStartTime;

            if (!_levelStarted && _currentTime > _startTime)
            {
                GameManager.Pause = false;
                Debug.Log("Play");
                GameManager.Instance.AudioManager.PlaySfx(3);
                _levelStarted = true;
                _textMeshPro.enabled = false;
                _textMeshPro2.enabled = true;
            }
            else if(!_levelStarted)
            {
                _textMeshPro.text = "Starts in... \n" + (_startTime - _currentTime).ToString("0.00");
            }

            if (_levelStarted && !_levelFinished && _currentTime > _levelTime + _startTime)
            {
                _levelFinished = true;
                _textMeshPro2.enabled = true;
                Finish();
            }
            else if (_levelStarted && !_levelFinished)
            {
                _textMeshPro2.text = (_levelTime + _startTime - _currentTime).ToString("0.00");
            }

        }

        private void Finish()
        {
            float max = -1;
            string player = "";


            foreach (var playerController in _players)
            {
                if (playerController._timeBeingAStar > max)
                {
                    player = playerController.gameObject.name;
                    max = playerController._timeBeingAStar;
                }
            }

            _textMeshPro2.enabled = false;
            _textMeshPro.enabled = true;

            _textMeshPro.text = player + " wins! \n" + max.ToString("0.00");

            GameManager.Pause = true;
            Debug.Log("Finish");

            StartCoroutine(LoadNextLevel());
        }

        private IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(5.0f);

            GameManager.Instance.ScenesManager.LoadScene(NextLevelName);
        }
    }
    

}
