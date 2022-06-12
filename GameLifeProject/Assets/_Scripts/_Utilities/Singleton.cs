using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T _SingleInstance;//Singleton instance for access

    protected virtual void Awake()//for Base method overriding access to a Singleton Classes
    {
        if(_SingleInstance == null){
           //Debug.Log(typeof(T).ToString() + " is NULL.");
           _SingleInstance = this as T;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
            //Debug.Log(typeof(T).ToString() + " has tried to instantiate again!");
        }
    }
}
