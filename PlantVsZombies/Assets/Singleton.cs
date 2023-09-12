using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }


    public static T Instance => _instance;
}
