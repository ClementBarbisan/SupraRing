using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreenScripts : MonoBehaviour {
 
    public Canvas startMenuCanvas ;

    // Back to start menu
    public void BackToStartMenu() {
        startMenuCanvas.gameObject.SetActive(true) ;
        gameObject.SetActive(false);
    }
}
