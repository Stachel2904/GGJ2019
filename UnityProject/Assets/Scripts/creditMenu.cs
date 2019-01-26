using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditMenu : MonoBehaviour
{
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
