using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shop
{
    public class CloseAdditiveSceneOnClick : MonoBehaviour
    {
        [SerializeField] private string sceneName = "BundleInfoScene";
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            // Verify if scene is actually loaded before unloading
            Scene scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.isLoaded)
            {
                Debug.LogWarning($"Scene '{sceneName}' is not currently loaded.");
                return;
            }

            // Unload asynchronously
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}