using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shop
{
    public class OpenBundleInfoButton : MonoBehaviour
    {
        //there are custom attributes that let you pick a scene from the project. But whatever (?) for now I guess...
        [SerializeField] private string sceneName = "BundleInfoScene";
        [SerializeField] private Button button;

        [SerializeField] private BundlePrototype prototype;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            //in a real project better scene loader required
            SceneManager.sceneLoaded += OnPreviewBundleSceneLoaded;
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private void OnPreviewBundleSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != sceneName)
                return;

            SceneManager.sceneLoaded -= OnPreviewBundleSceneLoaded;

            if (BundleInfoContext.PrototypeParent != null)
            {
                CopySelectedBundle();
            }
            else
            {
                Debug.LogError("BundleInfoContext.PrototypeParent not assigned in scene!");
            }
        }

        private void CopySelectedBundle()
        {
            var newPrototype = Instantiate(prototype.gameObject, BundleInfoContext.PrototypeParent, false);
            var newBundlePrototype = newPrototype.GetComponent<BundlePrototype>();
            newBundlePrototype.SetupBundlePrototypePreviewMode();
        }
    }
}
