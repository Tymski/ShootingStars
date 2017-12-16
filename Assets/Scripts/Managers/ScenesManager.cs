using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager : MonoBehaviour
    {
        [SerializeField]
        private string _loadingSceneName;

        private string _currentScene;

        private Coroutine _loadCoroutine;

        /// <summary>
        /// Loads scene asynchronously and shows loading screen.
        /// </summary>
        /// <param name="sceneName">Scene name to load</param>
        public void LoadScene(string sceneName)
        {
            _currentScene = SceneManager.GetActiveScene().name;

            if (_loadCoroutine != null)
            {
                Debug.LogError("Already loading scene!");
                return;
            }

            _loadCoroutine = StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Debug.Log("Load scene " + _loadingSceneName);

            var asyncOperation = SceneManager.LoadSceneAsync(_loadingSceneName, LoadSceneMode.Additive);

            yield return asyncOperation;

            yield return new WaitForSeconds(1.0f);

            Debug.Log("Unload scene " + _currentScene);

            asyncOperation = SceneManager.UnloadSceneAsync(_currentScene);

            yield return asyncOperation;

            yield return new WaitForSeconds(1.0f);

            Debug.Log("Load scene " + sceneName);

            asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            yield return asyncOperation;


            yield return new WaitForSeconds(1.0f);


            Debug.Log("Unload scene " + _currentScene);

            asyncOperation = SceneManager.UnloadSceneAsync(_loadingSceneName);

            yield return asyncOperation;

            yield return new WaitForSeconds(1.0f);
            Debug.Log("Success!");

            _currentScene = sceneName;
            _loadCoroutine = null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LoadScene("Level1");
            }
        }
    }
}