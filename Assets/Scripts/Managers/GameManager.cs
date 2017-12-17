using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(ScenesManager))]
    [RequireComponent(typeof(ScenesManager))]
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
        private AudioManager _audioManager;
    
        private ScenesManager _scenesManager;

        private LevelManager _levelManager;

        private InputManager.InputManager _inputManager;

        public static bool Pause;

        /// <summary>
        /// GameManager Singletone
        /// </summary>
        public static GameManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// AudioManager reference
        /// </summary>
        public AudioManager AudioManager
        {
            get { return _audioManager; }
        }

        /// <summary>
        /// ScenesManager reference
        /// </summary>
        public ScenesManager ScenesManager
        {
            get { return _scenesManager; }
        }

        public InputManager.InputManager InputManager
        {
            get { return _inputManager; }
        }

        /// <summary>
        /// LevelManager reference
        /// </summary>
        public LevelManager LevelManager
        {
            get
            {
                var manager = FindObjectOfType<LevelManager>();

                if (manager != null)
                    return manager;
                else
                    throw new UnityException("There is no LevelManager on this scene");
            }
        }

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
            {
                Destroy(gameObject);
                return; 
            }

            DontDestroyOnLoad(this);

            GetRequiredComponents();
        }

        private void GetRequiredComponents()
        {
            _audioManager = GetComponent<AudioManager>();
            _scenesManager = GetComponent<ScenesManager>();
            _inputManager = GetComponent<InputManager.InputManager>();
        }
    }
}