using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Method to exit the game
    public void Quit() {

        // If we are in Unity we close the Game Window
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                // If we are in the game built, we close the Game Window
                Application.Quit();
        #endif

    }

}
