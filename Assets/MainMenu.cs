using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void PlayGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(1);
    }
    public void GoBack()
    {
        Debug.Log("Went to main Menu");
        SceneManager.LoadScene(0);
    }
}
