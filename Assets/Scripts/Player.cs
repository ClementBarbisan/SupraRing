using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Rigidbody2D rb;

    // Thermal properties
    private float previousTemperature ;
    public float currentTemperature = 77.0f ;
	public float ambientTemperature = 300.0f ;
	private float alpha       = 0.1f  ;
	private float heaterPower = 1.0f  ;
	public float criticalTemperature = 93f;
	public bool isCharged = false;
	public bool isSupra = true;

	// Use this for initialization
	void Start () {
        // Set the previous temperature
        previousTemperature = currentTemperature ;
		rb = GetComponent<Rigidbody2D> ();
        // Set the initial color of the sprite
        GetComponent<SpriteRenderer>().color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // Update the player's temperature
        UpdateTemperature();

        // Handle the superconducting / normal transition
        SuperconductingTransition();

        // Lose the charge if not superconducting anymore
        if ( isCharged && !isSupra )
        {
            isCharged = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (Input.GetKeyDown (KeyCode.S))
			isSupra = !isSupra;
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
//			rb.velocity = transform.up;
			rb.AddForce (transform.up);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
//			rb.velocity = -transform.up;
			rb.AddForce (-transform.up);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
//			rb.velocity = -transform.right;
			rb.AddForce (-transform.right);
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
//			rb.velocity = transform.right;
			rb.AddForce (transform.right);
		}

	}

	// This function updates the character's temperature
	void UpdateTemperature()
	{
		// Current heater power
		float currentHeaterPower ;

		// Listen if the Heater key is pressed
		if (Input.GetKey (KeyCode.P)) {
			currentHeaterPower = heaterPower ;
		} else {
			currentHeaterPower = 0.0f ;
		}
        previousTemperature = currentTemperature ;
		// Compute the current temperature
		currentTemperature = previousTemperature + Time.deltaTime * 
                             ( alpha * (ambientTemperature - previousTemperature) + currentHeaterPower ) ;
	}

    // This function canges the superconducting state based on the player's temperature
    void SuperconductingTransition()
    {
        if ((currentTemperature <= criticalTemperature) &&
             (previousTemperature > criticalTemperature))
        {
            // Become superconducting
            isSupra = true;
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if ((currentTemperature >= criticalTemperature) &&
                  (previousTemperature < criticalTemperature))
        {
            // Become normal
            isSupra = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
