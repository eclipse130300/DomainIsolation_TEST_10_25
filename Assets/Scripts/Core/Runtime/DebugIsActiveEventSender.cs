using UnityEngine;
using UnityEngine.Events;

namespace Core.Runtime
{
    public class DebugIsActiveEventSender : MonoBehaviour
    {
        public UnityEvent OnDebugActive;
        public UnityEvent OnDebugInactive;
        private void OnEnable()
        {
#if DEBUG_ACTIVE
            OnDebugActive?.Invoke();
#else
            OnDebugInactive?.Invoke();  
#endif
        }
    }
}