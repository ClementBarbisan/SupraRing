using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {
	Player currentPlayer ;
	bool playerInside ;

	// Checks if the player presses "E" while on the dock, in that case
	// the player recieves the charge
	void Update () 
	{
		if ( Input.GetKeyDown(KeyCode.E) && playerInside )
		{
			currentPlayer.currentTemperature = 20f ;
			currentPlayer.isSupra = true;
			currentPlayer.GetComponent<SpriteRenderer>().color = Color.cyan;
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
