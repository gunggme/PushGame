using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool KeyCheck = false;

    private void Update()
    {
        KeyCheck = GameManager.KeyCheckCheck;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (KeyCheck)
        {
            GameManager.KeyCheck = true;
            this.gameObject.SetActive(false);
        }
    }
}
