using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingeton : MonoBehaviour
{
    private static BaseSingeton _instance;

    public static BaseSingeton Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

}
