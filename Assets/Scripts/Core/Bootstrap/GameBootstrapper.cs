using Core.Runtime;
using UnityEngine;

namespace Core.Bootstrap
{
    //bootstapper itself should be in a separate scene.
    //but for the sake of simplicity, I put it in the main scene -
    //and just use script execution order to make sure it runs first.
    public class GameBootstrapper : MonoBehaviour
    {
        //we can create custom bootstaping logic here.
        //for now, we just create all necessary data with all values.
        //but later we can look for saved data / create a server request.
        [SerializeReference] [SelectableImpl] 
        private IBootstappable[] Bootstappables;
        private void Awake()
        {
            foreach (var bootstappable in Bootstappables)   
                bootstappable.Bootstrap();
        }
    }
}