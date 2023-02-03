using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Menu menu;

    private void Update()
    {
        keyCheche = KeyCheckCheck;
        keyCheck = KeyCheck;

        GetKey();
        KeyGetting();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Coins = 7000;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            KeyCheck = true;
        }

        GamePause();
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
        if (Coins <= 6900)
        {
            KeyCheckCheck = true;
        }
    }

    void GamePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Menu.isPause)
                menu.PauseGame();
            else
                menu.ContinueGame();
        }
    }

}
