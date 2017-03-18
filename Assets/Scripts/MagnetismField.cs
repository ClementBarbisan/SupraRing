using UnityEngine;
using System.Collections;

public class MagnetismField : MonoBehaviour {

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
			user.rb.velocity += new Vector2(user.gameObject.transform.position.x - hit.point.x, user.gameObject.transform.position.y - hit.point.y);
		}
	}
}
