using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingDockBehavior : MonoBehaviour {

    // Variables :
    //  - currentPlayer = Player in the charging dock
    //  - playerInside  = Boolean set to true when a player
    //                    is in the dock

    private Player currentPlayer ;
    private bool playerInside ;
    
    private AudioSource audioSource ;
    private AudioClip soundEffect ;

    // This function is called on startup
    private void Start()
    {
        audioSource = GetComponent<AudioSource>() ;
        soundEffect = audioSource.clip ;
    }


    // Checks if the player presses "E" while on the dock, in that case
    // the player recieves the charge
	void Update () {
		if ( (Input.GetKey(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button16)) && playerInside && !currentPlayer.isCharged )
        {
            // Set the player to be charged
            currentPlayer.isCharged = true ;
            // Edit its appearance
//            currentPlayer.GetComponent<SpriteRenderer>().color = Color.yellow ;
            // Play the corresponding sound
            if ( !audioSource.isPlaying )
            {
                audioSource.PlayOneShot(soundEffect, 1.0f) ;
            }
        }
	}

    // Called when the player steps into the charging deck
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.GetComponent<Player>() )
        {
            currentPlayer = other.GetComponent<Player>() ;
            playerInside = true ;
        }
    }

    // Called when the player walks out of th charging dock
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            playerInside = false;
        }
    }
}
