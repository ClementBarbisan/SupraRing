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
		if (other.GetComponent<Player> () && other.GetComponent<Player>().isSupra)
		{
			Player user = other.GetComponent<Player> ();
			RaycastHit2D hit = Physics2D.Raycast(user.gameObject.transform.position, user.gameObject.transform.position - transform.position);
			Vector2 direction = (transform.position - user.gameObject.transform.position).normalized;
			float magnitude = Mathf.Clamp(1.0f / Mathf.Pow(hit.distance, 2), 0.0f, 100f);
			user.rb.velocity += magnitude * direction;
		}
	}
}
