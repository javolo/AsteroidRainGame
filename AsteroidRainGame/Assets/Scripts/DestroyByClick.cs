using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByClick : MonoBehaviour {

    // Declaration of Score Value variable
    public int scoreValue;

    // Declaration of Hazzard object
    public GameObject hazzard;

    // Declaration of the Explosion variable
    //public GameObject explosion;

    // We need to create an specific object because if we access directly with the class
    // we can have different instances of it and ambiguity
    private GameController gameController;

    // We need to find the game object that hold our Game Controller Script
    void Start()
    {
        // That looks for the first Game Controller tag in the game ans assigns its reference
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            // If we find the reference we assign to the variable in the script the reference found
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        // We print in the log a message if we couldn´t find the reference of Game Controller in the game.
        if (gameController == null)
        {
            Debug.Log("Can not find Game Controller Script");
        }
    }

    void OnMouseDown() {

        // If the asteroid is big we have to spawn two small one
        if (gameObject.tag == "BigAsteroid") {
            // We destroy the object we click with the mouse
            Destroy(gameObject);

            // We spawn to small asteroids
            Vector3 spawnPosition = new Vector3(
                Mathf.Clamp(Random.Range(gameObject.transform.position.x-2, gameObject.transform.position.x), -gameController.spawnValues.x, gameController.spawnValues.x),
                gameObject.transform.position.y,
                Random.Range(gameObject.transform.position.z-1, gameObject.transform.position.z+1));
            // Declaration of Spawn Rotation as a Quaternion
            Quaternion spawnRotation = Quaternion.identity;
            // We instantiate the hazzards
            Instantiate(hazzard, spawnPosition, spawnRotation);
            spawnPosition = new Vector3(
                Mathf.Clamp(Random.Range(gameObject.transform.position.x, gameObject.transform.position.x+1), -gameController.spawnValues.x, gameController.spawnValues.x),
                gameObject.transform.position.y,
                Random.Range(gameObject.transform.position.z - 1, gameObject.transform.position.z + 1));
            // We instantiate the hazzards
            Instantiate(hazzard, spawnPosition, spawnRotation);

            //We add the value calling the function in the GameController class
            gameController.AddScore(scoreValue+1);
        } else {
            // We destroy the object we click with the mouse
            Destroy(gameObject);
            //We add the value calling the function in the GameController class
            gameController.AddScore(scoreValue);
        }
    }


}
