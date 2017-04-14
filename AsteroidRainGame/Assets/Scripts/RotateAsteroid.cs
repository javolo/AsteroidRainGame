using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAsteroid : MonoBehaviour {

    // Declaration of variable to randomize the rotation
    public float rotation;
    // Declaration of Rigidbody variable
    private Rigidbody rb;

    // Use this for initialization
    void Start() {

        // We obtain the rigidbody component
        rb = GetComponent<Rigidbody>();
        // We take the angular velocity of the object and randomize it
        rb.angularVelocity = Random.insideUnitSphere * rotation;
    }
}