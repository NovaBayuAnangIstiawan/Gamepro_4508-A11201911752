using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene ("Scenes/Main");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("Scenes/credits");
    }

    public void OnHelp()
    {
        SceneManager.LoadScene("Scenes/batuan");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }


}
