using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScenes : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }
    
    public void SettingsButton()
    {
         SceneManager.LoadScene("Settings",LoadSceneMode.Single);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("ZigZagEasy",LoadSceneMode.Single);
        StaticClass.Lives = 3;
    }

    public void ControlsButton()
    {
        SceneManager.LoadScene("Controls",LoadSceneMode.Single);
    }

    public void AboutGameButton()
    {
        SceneManager.LoadScene("AboutGame",LoadSceneMode.Single);
    }

}
