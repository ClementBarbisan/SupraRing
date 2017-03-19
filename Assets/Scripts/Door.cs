using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public Switch currentSwitch;
	private bool open;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSwitch.turnOn && !open)
		{
			open = true;
			anim.Play ("door");
			anim.speed = 1.0f;
			GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
