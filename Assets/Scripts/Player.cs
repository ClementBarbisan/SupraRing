﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Rigidbody2D rb;

    // Thermal properties
    private float previousTemperature ;
    public float currentTemperature = 77.0f ;
	public float ambientTemperature = 300.0f ;
	public float alpha       = 0.1f  ;
	public float speed		= 10f;
	private float heaterPower = 1.0f  ;
	public float criticalTemperature = 93f;
	public bool isCharged = false;
	public bool isSupra = true;
	public Slider sliderTemperature;
	private Animator anim;
	private Vector3 localScale;

	// Use this for initialization
	void Start () {
        // Set the previous temperature
        previousTemperature = currentTemperature ;
		rb = GetComponent<Rigidbody2D> ();
        // Set the initial color of the sprite
//        GetComponent<SpriteRenderer>().color = Color.red;
		anim = GetComponent<Animator> ();
		localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // Update the player's temperature
        UpdateTemperature();
		if (!isSupra)
			anim.SetBool ("isSupra", false);
		if (!isCharged)
			anim.SetBool ("isCharged", false);
        // Handle the superconducting / normal transition
        SuperconductingTransition();

        // Lose the charge if not superconducting anymore
        if ( isCharged && !isSupra )
        {
            isCharged = false;
//            GetComponent<SpriteRenderer>().color = Color.red;
        }

//        if (Input.GetKeyDown (KeyCode.S))
//			isSupra = !isSupra;
		if (Input.GetAxis ("Vertical") != 0.0f)
		{
//			transform.Translate (transform.up * Time.deltaTime * speed);
//			rb.velocity = transform.up;
			rb.AddForce (new Vector2(0.0f, Input.GetAxis("Vertical")) * speed * 10f);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			anim.speed = Mathf.Abs(rb.velocity.y);
		}
		if (Input.GetAxis ("Horizontal") != 0.0f)
		{
			//			transform.Translate (transform.up * Time.deltaTime * speed);
			//			rb.velocity = transform.up;
			rb.AddForce (new Vector2(Input.GetAxis("Horizontal"), 0.0f) * speed * 10f);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			anim.speed = Mathf.Abs(rb.velocity.x);
			transform.localScale = new Vector3 (localScale.x * Mathf.Sign(Input.GetAxis("Horizontal")), localScale.y, localScale.z);
		}
		if (Input.GetKey (KeyCode.UpArrow))
		{
//			transform.Translate (transform.up * Time.deltaTime * speed);
//			rb.velocity = transform.up;
			rb.AddForce (transform.up * speed);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			anim.speed = Mathf.Abs(rb.velocity.y * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
//			transform.Translate (-transform.up * Time.deltaTime * speed);
//			rb.velocity = -transform.up;
			rb.AddForce (-transform.up * speed);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			anim.speed = Mathf.Abs(rb.velocity.y * speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
//			transform.Translate (-transform.right * Time.deltaTime * speed);
//			rb.velocity = -transform.right;
			rb.AddForce (-transform.right * speed);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			transform.localScale = new Vector3 (-localScale.x, localScale.y, localScale.z);
			anim.speed = Mathf.Abs(rb.velocity.x * speed);
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
//			transform.Translate (transform.right * Time.deltaTime * speed);
//			rb.velocity = transform.right;
			rb.AddForce (transform.right * speed);
			if (isCharged)
				anim.SetBool ("isCharged", true);
			if (isSupra)
				anim.SetBool ("isSupra", true);
			anim.SetBool ("move", true);
			transform.localScale = localScale;
			anim.speed = Mathf.Abs(rb.velocity.x * speed);
		}
		if (!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow) && Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f)
		{
			anim.speed = 1f;
			anim.SetBool ("move", false);
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
		sliderTemperature.value = currentTemperature / 300f;
	}

    // This function changes the superconducting state based on the player's temperature
    void SuperconductingTransition()
    {
        if ((currentTemperature <= criticalTemperature) &&
             (previousTemperature > criticalTemperature))
        {
            // Become superconducting
            isSupra = true;
//            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if ((currentTemperature >= criticalTemperature) &&
                  (previousTemperature < criticalTemperature))
        {
            // Become normal
            isSupra = false;
//            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
