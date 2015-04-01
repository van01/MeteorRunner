using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T sInstance = null;

    public static T instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = (T)FindObjectOfType(typeof(T));
            }

            if (sInstance == null)
            {
                Create();
            }

            return sInstance;
        }
    }

    private static void Create()
    {
        if (GameObject.Find("_Singleton"))
        {
            GameObject goInst = GameObject.Find("_Singleton");
            sInstance = goInst.AddComponent<T>();
        }
        else
        {
            GameObject goInst = new GameObject("_Singleton");
            sInstance = goInst.AddComponent<T>();
        }
    }
}