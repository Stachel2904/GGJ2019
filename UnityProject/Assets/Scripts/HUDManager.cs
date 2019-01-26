using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public static HUDManager Get()
    {
        return GameObject.Find("HUD").GetComponent<HUDManager>();
    }

    // Update is called once per frame
    public void UpdateLPBar(int currentLP, int maxLP)
    {
        RectTransform bar = GameObject.Find("LPBar").GetComponent<RectTransform>();

        Vector3 newBarPos = new Vector2(-1 * (bar.rect.width / maxLP) * (maxLP - currentLP), bar.localPosition.y);
        
        bar.localPosition = newBarPos;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void continueGame()
    {
        Time.timeScale = 1;
    }
}
