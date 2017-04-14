using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Declaration of Speed variable
    public float speed;
    // Declaration of Rigidbody variable
    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        // We obtain the rigidbody component
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

    }
	
	
}
