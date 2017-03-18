using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Rigidbody2D rb;
	public float temperature = -273.0f;
	public bool isSupra = true;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.S))
			isSupra = !isSupra;
		if (temperature < 0.0f)
			temperature += Time.deltaTime;
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

}
