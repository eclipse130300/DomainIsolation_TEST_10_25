using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BundlePrototype : MonoBehaviour
    {
        [SerializeField] Button _infoButton;

        public void SetupBundlePrototypePreviewMode()
        {
            _infoButton.gameObject.SetActive(false);
        }
    }
}