using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("ForestLevel1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}