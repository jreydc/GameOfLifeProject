using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static T _instance;
    public static T Instance{
        get{return _instance;}
    }

    protected virtual void Awake() {
        if(_instance == null){
           //Debug.Log(typeof(T).ToString() + " is NULL.");
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            //Debug.Log(typeof(T).ToString() + " has tried to instantiate again!");
        }
    }
}
