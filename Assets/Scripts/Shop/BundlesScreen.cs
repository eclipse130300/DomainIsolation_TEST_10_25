using Shop.Bundles;
using UnityEngine;

namespace Shop
{
    public class BundlesScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _bundlePrototypePrefab;
        [SerializeField] private Transform _contentParent;
        
        private const string BUNDLES_FOLDER = "Bundles";
        private BundleSO[] _availableBundles;

        public void Awake()
        {
            _availableBundles = Resources.LoadAll<BundleSO>(BUNDLES_FOLDER);
        }

        private void Start()
        {
            // Clear existing bundle prototypes
            foreach (Transform child in _contentParent)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var bundle in _availableBundles)
            {
                Debug.Log($"Bundle available: {bundle.BundleName}, Can be purchased: {bundle.CanBePurchased()}");
                
                var bundleGO = Instantiate(_bundlePrototypePrefab, _contentParent);
                var bundlePrototype = bundleGO.GetComponent<BundlePrototype>();
                bundlePrototype.Setup(bundle);
            }
        }
    }
}
