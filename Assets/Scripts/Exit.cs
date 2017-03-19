using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	public string sceneName;
	private bool isInsideAndCharged = false;
	private Player currentPlayer;

    private AudioSource audioSource ;
    private AudioClip activeSound ;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>() ;
        activeSound = audioSource.clip ;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button16)) && isInsideAndCharged)
		{
			currentPlayer.isCharged = false ;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(activeSound, 0.8f) ;
            }
			StartCoroutine (LoadNextScene ()) ;
		}

	}

	IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (sceneName);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player> () && other.GetComponent<Player> ().isCharged)
		{
			isInsideAndCharged = true;
			currentPlayer = other.GetComponent<Player> ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Player> ())
		{
			isInsideAndCharged = false;
		}
	}
}
