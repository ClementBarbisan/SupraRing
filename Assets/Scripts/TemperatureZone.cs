using UnityEngine;
using System.Collections;

public class TemperatureZone : MonoBehaviour {
	public float currentTemperature = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player> ())
			other.GetComponent<Player> ().ambientTemperature = currentTemperature;
	}
}
