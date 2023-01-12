using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float Coins = 0;
    public static bool KeyCheckCheck = false;
    public static bool KeyCheck = false;
    public bool keyCheck;
    public bool keyCheche;
    public Text CoinText;
    public GameObject Block;
    public GameObject Clearer;

    private void Update()
    {
        keyCheche = KeyCheckCheck;
        keyCheck = KeyCheck;

        GameOver();
        GetKey();
        KeyGetting();
        if(Input.GetKeyDown(KeyCode.T))
        {
            Coins = 7000;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            KeyCheck= true;
        }
    }

    public void GameOver()
    {

    }

    public void GetKey()
    {
        CoinText.text = Coins.ToString() + "¿ø";
        if (KeyCheck)
        {
            Block.SetActive(false);
            Clearer.SetActive(true);
        }
    }

    public void KeyGetting()
    {
        if(Coins <= 6900)
        {
            KeyCheckCheck = true;
        }
    }

}
