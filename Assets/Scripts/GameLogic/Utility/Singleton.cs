﻿using UnityEngine;

namespace Asteroids.Utility
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object m_Lock = new object();
        private static T m_Instance;

        public virtual void Awake()
        {
            if (m_Instance != null) Destroy(this);
        }

        public static T Instance
        {
            get
            {
                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = (T)FindObjectOfType(typeof(T));
                        if (m_Instance == null)
                        {
                            var singletonObject = new GameObject();
                            m_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return m_Instance;
                }
            }
        }
    }
}