using System;
using UnityEngine;

namespace Assets.Scripts._4.CORE.Frameworks
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent(GetTypes()) as T;
                            singleton.name = "(singleton)" + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }

        private static Type GetTypes()
        {
            return typeof(T);
        }
    }
}