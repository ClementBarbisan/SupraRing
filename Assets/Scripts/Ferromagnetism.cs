using UnityEngine;
using System.Collections;

public class Ferromagnetism : MonoBehaviour {
	public float quotient = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.GetComponent<Player> () && other.GetComponent<Player>().isSupra && other.GetComponent<Player>().isCharged)
		{
			Player user = other.GetComponent<Player> ();
			RaycastHit2D hit = Physics2D.Raycast(user.gameObject.transform.position, user.gameObject.transform.position - transform.position);
			float angle = Vector2.Angle (user.gameObject.transform.position - transform.position, hit.normal);
			RaycastHit2D currentHit;
			float distance = hit.distance;
			int nb = 0;
			for (int i = 1; i <= angle / 10; i++)
			{
				hit = Physics2D.Raycast (user.gameObject.transform.position, Quaternion.Euler (0.0f, 0.0f, 10.0f * i) * (user.gameObject.transform.position - transform.position));
				if (hit.distance < distance)
				{
					nb = i;
					distance = hit.distance;
					currentHit = hit;
				}
			}
			Vector2 direction = (transform.position - user.gameObject.transform.position).normalized;
			float magnitude = Mathf.Clamp(1.0f / Mathf.Pow(hit.distance, 2), 0.0f, 100f);
			if (nb != 0)
			{
				direction = Quaternion.Euler(0.0f, 0.0f, 10.0f * nb) * (transform.position - user.gameObject.transform.position).normalized;
				magnitude = Mathf.Clamp(1.0f / Mathf.Pow(currentHit.distance, 2), 0.0f, 100f);
			}
			user.rb.velocity += magnitude * direction * quotient;
		}
	}
}
