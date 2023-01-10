using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if(_instance == null)
                {
                    Debug.LogError("현재 씬에서 " + typeof(T) + "를 활성화 할 수 없습니다.");
                }
            }
            return _instance;
        }
    }

    //파괴되지 않는 오브젝트로 만들려면 주석을 품
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
