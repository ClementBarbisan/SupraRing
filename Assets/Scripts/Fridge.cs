using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {
	Player currentPlayer ;
	bool playerInside ;

    private AudioSource ambientAudio ;
    private AudioSource activeAudio ;
    public AudioClip coolingDockAmbient ;
    public AudioClip coolingDown ;

    private void Awake()
    {
        activeAudio = AddAudio(coolingDown, false, false, 1.0f) ;
    }

    // Checks if the player presses "E" while on the dock, in that case
    // the player recieves the charge
    void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Joystick1Button0))
			Debug.Log ("Push button");
		if ( (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button16)) && playerInside)
		{
			currentPlayer.currentTemperature = 20f ;
			currentPlayer.isSupra = true;
            if ( !activeAudio.isPlaying )
            {
                activeAudio.PlayOneShot(coolingDown, 1.0f);
            }
		}
	}

	// Called when the player steps into the charging deck
	private void OnTriggerEnter2D(Collider2D other)
	{
		if ( other.GetComponent<Player>() )
		{
			currentPlayer = other.GetComponent<Player>() ;
			playerInside = true ;
		}
	}

	// Called when the player walks out of th charging dock
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.GetComponent<Player>())
		{
			playerInside = false;
		}
	}

    // Add audio sources to the component
    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip ; 
        newAudio.loop = loop ;
        newAudio.playOnAwake = playAwake ;
        newAudio.volume = vol ; 
        return newAudio ; 
    }
}
