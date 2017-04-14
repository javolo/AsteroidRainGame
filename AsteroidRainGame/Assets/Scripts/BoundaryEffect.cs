using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryEffect : MonoBehaviour {

    // We need to create an specific object because if we access directly with the class
    // we can have different instances of it and ambiguity
    private GameController gameController;

    // Variable to see if we flash the screen or not
    private bool flashScreen;

    // We need to find the game object that hold our Game Controller Script
    void Start() {
        // That looks for the first Game Controller tag in the game ans assigns its reference
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            // If we find the reference we assign to the variable in the script the reference found
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        // We print in the log a message if we couldn´t find the reference of Game Controller in the game.
        if (gameController == null) {
            Debug.Log("Can not find Game Controller Script");
        }

        // Set boolean variable to flash the screen to false
        flashScreen = false;
    }

    //bFlashed is a boolean (you can name it what ever you like)
    void OnGUI() {

        // If an asteroid hit the bottom of the screen we make the border red
        if (flashScreen) {

            //Creates 2D texture
            Texture2D tx2DFlash = new Texture2D(1, 1);
            //Sets the 1 pixel to be red
            tx2DFlash.SetPixel(0, 0, Color.red);
            //Applies all the changes made
            tx2DFlash.Apply();

            Rect position = new Rect(0, 0, Screen.width, Screen.height);
            //Draws the texture for the entire screen (width, height)
            GUI.DrawTexture(position, tx2DFlash);
            StartCoroutine(SetFlashFalse());
        }
    }

    // Coroutine to have the flash screen only 0.2 seconds
    IEnumerator SetFlashFalse() {
        //Waits 1 second before setting boolean to false
        yield return new WaitForSeconds(0.2f);
        // Set the variable to false again
        flashScreen = false;
    }

    // Function that destroy the asteroid when reach out the boundaries.
    void OnCollisionEnter(Collision collision) {

        // We only want to destroy the asteroid when hit the bottom boundary, 
        // so we check the tag in order to destroy the asteroid
        if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "BigAsteroid") {

            // We update the life text
            gameController.RemoveLife();

            // We mark the object to be destroyed
            Destroy(collision.gameObject);

            // We set the variable to flash the screen to true
            GameData.Instance.setActiveBorders(true);
            //flashScreen = true;
        }
    }
}
