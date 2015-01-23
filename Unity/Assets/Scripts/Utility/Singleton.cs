using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    /**
       Returns the instance of this singleton.
    */
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    singletonObject.name = "_singleton " + typeof(T).ToString();
                    T newSingletonInstance = singletonObject.AddComponent<T>();
                    instance = (T)FindObjectOfType(typeof(T));
                    DontDestroyOnLoad(singletonObject);
                    //Debug.Log("An instance of " + typeof(T) +
                    //   " is needed in the scene, but there is none. Created new instance.", DebugLogType.Warning);
                }
            }

            return instance;
        }
    }

    void OnApplicationQuit()
    {
        Destroy(this.gameObject);
    }
}
