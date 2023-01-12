using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Coins += 100;
        this.gameObject.SetActive(false);
    }
}
