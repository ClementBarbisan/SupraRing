using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (sceneName);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown (KeyCode.E) && other.GetComponent<Player> () && other.GetComponent<Player> ().isCharged)
		{
			other.GetComponent<Player> ().isCharged = false;
			StartCoroutine (LoadNextScene());
		}
	}
}
