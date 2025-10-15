using UnityEngine;

namespace Core
{
    public class PlayerData : MonoBehaviour
    {
        private static PlayerData _instance;

        public static PlayerData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerData>();
                    if (_instance == null)
                    {
                        var go = new GameObject(nameof(PlayerData));
                        _instance = go.AddComponent<PlayerData>();
                        DontDestroyOnLoad(go);
                    }
                }

                return _instance;
            }
        }

        private static class Storage<T>
        {
            public static T Value;
            public static bool HasValue;
        }

        public void Set<T>(T data)
        {
            Storage<T>.Value = data;
            Storage<T>.HasValue = true;
        }


        public bool TryGet<T>(out T data)
        {
            if (Storage<T>.HasValue)
            {
                data = Storage<T>.Value;
                return true;
            }

            data = default;
            return false;
        }


        public T GetOrCreate<T>() where T : new()
        {
            if (!Storage<T>.HasValue)
            {
                Storage<T>.Value = new T();
                Storage<T>.HasValue = true;
            }

            return Storage<T>.Value;
        }

        public void Remove<T>()
        {
            Storage<T>.Value = default;
            Storage<T>.HasValue = false;
        }
    }
}