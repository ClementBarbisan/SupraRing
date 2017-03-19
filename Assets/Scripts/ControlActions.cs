using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlActions : MonoBehaviour {

    public string firstLevel ;
    public Canvas storyCanvas ;
    public Canvas controlCanvas ;
    public Canvas creditsCanvas ;

    // Launch first level
    public void LoadLevel()
    {
        SceneManager.LoadScene(firstLevel) ;
    }

    // Go to story menu
    public void GoToStory()
    {
        
        storyCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    // Go to control menu
    public void GoToControls() {
        controlCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    

    // Go to credits menu
    public void GoToCredits()
    {
        creditsCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    // This function exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
