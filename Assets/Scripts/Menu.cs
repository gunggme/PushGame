using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text title;
    public static bool isPause;

    public enum MenuStatus
    {
        None,
        Pause,
        Clear,
        GameOver,
        Continue,
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        title = title.GetComponent<Text>();
    }


    public void SetMenu(MenuStatus menustatus)
    {
        switch (menustatus)
        {
            case MenuStatus.Pause:
                title.text = "Pause";
                break;
            case MenuStatus.Clear:
                title.text = "Clear";
                break;
            case MenuStatus.GameOver:
                title.text = "GameOver";
                break;
            case MenuStatus.Continue:
                title.text = "Continue";
                break;
            case MenuStatus.None:
                title.text = "None";
                break;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
        gameObject.SetActive(true);

        SetMenu(Menu.MenuStatus.Pause);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        isPause = false;
        gameObject.SetActive(false);

        SetMenu(Menu.MenuStatus.Continue);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Map");
        isPause = false;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
}
