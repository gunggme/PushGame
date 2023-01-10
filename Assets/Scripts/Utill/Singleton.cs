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
                    Debug.LogError("���� ������ " + typeof(T) + "�� Ȱ��ȭ �� �� �����ϴ�.");
                }
            }
            return _instance;
        }
    }

    //�ı����� �ʴ� ������Ʈ�� ������� �ּ��� ǰ
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
