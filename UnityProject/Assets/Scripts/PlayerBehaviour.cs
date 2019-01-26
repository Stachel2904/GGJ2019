using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int CurrentLivePoints { get; private set; } = 1000;
    public int CurrentScorePoints { get; set; } = 0;

    public void RemoveLivePoints(int amount)
    {
        CurrentLivePoints -= amount;
        HUDManager.Get().UpdateLPBar(CurrentLivePoints, 1000);

        if(CurrentLivePoints <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        HUDManager.Get().LoseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        HUDManager.Get().LoseScreen.transform.Find("Score").gameObject.GetComponent<Text>().text = (Gamster.Get().killedEnemys * 25).ToString();
    }
}
