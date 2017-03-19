using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	private bool isInsideAndCharged = false;
	private Player currentPlayer;
	public bool turnOn = false;
	public Sprite onSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button16)) && isInsideAndCharged)
		{
			turnOn = true;
			GetComponent<SpriteRenderer> ().sprite = onSprite;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player> () && other.GetComponent<Player> ().isCharged)
		{
			isInsideAndCharged = true;
			currentPlayer = other.GetComponent<Player> ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Player> ())
		{
			isInsideAndCharged = false;
		}
	}
}
