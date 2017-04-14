using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Method to load Main Scene
    public void LoadMainScene() {

        // Call to the method that load the Main Scene when click the Start Button
        SceneManager.LoadScene("Main");
    }

}
