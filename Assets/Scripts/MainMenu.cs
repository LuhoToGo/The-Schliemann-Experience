using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameA(){
        SceneManager.LoadScene(1);
    }

    public void PlayGameB(){
        //SceneManager.LoadScene(2);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ToggleScreenMode(){
        if(Screen.fullScreenMode == FullScreenMode.Windowed){
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        } 
    }
}
