using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(ScenesManager))]
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
    
        private AudioManager _audioManager;
    
        private ScenesManager _scenesManager;

        private LevelManager _levelManager; 


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
                Destroy(this);
                return; 
            }

            DontDestroyOnLoad(this);

            GetRequiredComponents();
        }

        private void GetRequiredComponents()
        {
            _audioManager = GetComponent<AudioManager>();
            _scenesManager = GetComponent<ScenesManager>();
        }
    }
}