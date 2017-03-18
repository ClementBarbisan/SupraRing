using UnityEngine;
using System.Collections;

public class TemperatureZone : MonoBehaviour {

    // Ambient temperature in the area
    public float areaTemperature = 77.0f ;

    // This function sets the player's ambient temperature when it enters the area
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().ambientTemperature = areaTemperature ;
        }
	}

    // This function resets the player's ambient temperature when it leaves the area
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().ambientTemperature =
                Camera.main.GetComponent<Parameters>().defaultAmbientTemperature ;
        }
    }

}
