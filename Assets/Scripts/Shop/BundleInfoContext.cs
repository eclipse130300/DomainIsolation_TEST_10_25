using UnityEngine;

namespace Shop
{
    public class BundleInfoContext : MonoBehaviour
    {
        public static Transform PrototypeParent { get; private set; }

        [SerializeField] private Transform prototypeParent;

        private void Awake()
        {
            PrototypeParent = prototypeParent;
        }

        private void OnDestroy()
        {
            if (PrototypeParent == prototypeParent)
                PrototypeParent = null;
        }
    }
}
