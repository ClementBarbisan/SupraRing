using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Rigidbody2D rb;

	// Thermal properties
	public float temperature = 77.0f ;
	public float ambientTemperature = 300.0f ;
	private float alpha       = 0.1f  ;
	private float heaterPower = 1.0f  ;

	public bool isSupra = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateTemp ();

		if (Input.GetKeyDown (KeyCode.S))
			isSupra = !isSupra;
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
//			rb.velocity = transform.up;
			rb.AddForce (transform.up * 10);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
//			rb.velocity = -transform.up;
			rb.AddForce (-transform.up * 10);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
//			rb.velocity = -transform.right;
			rb.AddForce (-transform.right * 10);
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
//			rb.velocity = transform.right;
			rb.AddForce (transform.right * 10);
		}

	}

	// This function updates the character's temperature
	void UpdateTemp()
	{
		// Current heater power
		float currentHeaterPower ;

		// Listen if the Heater key is pressed
		if (Input.GetKey (KeyCode.P)) {
			currentHeaterPower = heaterPower ;
		} else {
			currentHeaterPower = 0.0f ;
		}
		// Compute the current temperature
		temperature = temperature + Time.deltaTime * ( alpha * (ambientTemperature - temperature) + currentHeaterPower ) ;
	}

}
