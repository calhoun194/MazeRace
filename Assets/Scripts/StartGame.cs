using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    static public int difficulty;
    // Start is called before the first frame update

    public void setEasyValue()
    {
        difficulty = 50;
    }

    public void setMediumValue()
    {
        difficulty = 30;
    }

    public void setHardValue()
    {
        difficulty = 2;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}

