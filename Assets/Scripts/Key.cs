using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool KeyChecks = false;

    private void Update()
    {
        KeyChecks = GameManager.KeyCheckCheck;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (KeyChecks)
        {
            GameManager.KeyCheck = true;
            this.gameObject.SetActive(false);
        }
    }
}
