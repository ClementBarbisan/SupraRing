using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingDockBehavior : MonoBehaviour {

    // 
    Player currentPlayer ;
    bool playerInside ;

	// Update is called once per frame
	void Update () {
		if ( Input.GetKey(KeyCode.E) && playerInside )
        {
            Debug.Log("Charged !");
            currentPlayer.isCharged = true ;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered the charging dock");
        if ( other.GetComponent<Player>() )
        {
            currentPlayer = other.GetComponent<Player>() ;
            playerInside = true ;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            playerInside = false;
        }
    }
}
