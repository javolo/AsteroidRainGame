using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyElements : MonoBehaviour {

    // Variable to wait between call to Destroy
    public float lifetime;

	// Use this for initialization
	void Start () {
        
        // We destroy the elements holding in the game like explosions
        // Set the object to be destroyed and when the time is up the system perfoms the action
        Destroy(gameObject, lifetime);
	}
	
}
