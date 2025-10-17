using Core.Runtime;
using Shop.Bundles;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class AddResourceCheatButton : MonoBehaviour
    {
        [SerializeField] private Button _cheatButton;
        
        [SerializeReference] [SelectableImpl] 
         private IBundleBrick _cheatBundleBrick;
        
        private void Awake()
        {
            _cheatButton.onClick.AddListener(OnCheatButtonClicked);
        }
        
        private void OnCheatButtonClicked()
        {
            if (_cheatBundleBrick.IsAvailable())
            {
                _cheatBundleBrick.Apply();
            }
        }
    }   
}