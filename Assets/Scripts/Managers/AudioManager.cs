using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] _backgroundAudioClips;

        [SerializeField]
        private AudioClip[] _sfxs;

        private AudioSource _backgroundMusic;

        private void Awake()
        {
            _backgroundMusic = GetComponent<AudioSource>();
        }

        public void PlayMusic(int id = 0)
        {
            if (_backgroundAudioClips.Length >= id)
            {
                Debug.LogWarning("There is no music with that id.");
                return;
            }

            _backgroundMusic.clip = _backgroundAudioClips[id];
            _backgroundMusic.Play();
        }

        public void StopMusic()
        {
            _backgroundMusic.Stop();
        }

        public void ChangeVolume(float volume)
        {
            _backgroundMusic.volume = volume;
        }

        public void PlaySfx(int id)
        {
            if (_sfxs.Length >= id)
            {
                Debug.LogWarning("There is no sfx with that id.");
                return;
            }

            AudioSource.PlayClipAtPoint(_sfxs[id], Camera.main.transform.position);
        }
    }
}