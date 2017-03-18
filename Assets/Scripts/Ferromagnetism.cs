﻿using UnityEngine;
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
			RaycastHit2D hit = new RaycastHit2D();
			Physics2D.Raycast(user.gameObject.transform.position, user.gameObject.transform.position - transform.position, out hit);
			user.rb.velocity += new Vector2(user.gameObject.transform.position.x - hit.point.x, user.gameObject.transform.position.y - hit.point.y);
		}
	}
}
