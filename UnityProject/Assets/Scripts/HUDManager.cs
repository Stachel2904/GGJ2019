using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        RectTransform mask = this.gameObject.transform.Find("LPBarMask").GetComponent<RectTransform>();

        Vector3 newMaskPos = new Vector2(-1 * (Screen.width / maxLP) * (maxLP - currentLP) + Screen.width / 2, mask.position.y);
        Vector3 Movement = mask.position - newMaskPos;
        mask.position = newMaskPos;
        mask.GetChild(0).position += Movement;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
