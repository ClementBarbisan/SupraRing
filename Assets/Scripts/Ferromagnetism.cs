using UnityEngine;
using System.Collections;

public class Ferromagnetism : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.GetComponent<Player> ())
		{
			Player user = other.GetComponent<Player> ();
			user.rb.velocity += new Vector2(transform.position.x - user.gameObject.transform.position.x, transform.position.y - user.gameObject.transform.position.y);
		}
	}
}
