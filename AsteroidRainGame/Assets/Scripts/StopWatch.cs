using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    // Declaration of timer variable starting at 60
    public float timer;
    // Declaration of Text Variable
    public Text stopWatch;

    // Use this for initialization
    void Start() {

        // We get the Text of the UI element in the Game Scene
        stopWatch = GetComponent<Text>() as Text;
    }

	// Update is called once per frame
	void Update () {

        // We remove the delta time each frame
        timer -= Time.deltaTime;

        // We change the colour depending how much time left the player has
        if (timer<= 30 && timer > 10) {
            // Yellow colour for the mid interval between 30 and 10 seconds left
            stopWatch.color = Color.yellow;
        } else if (timer <= 10 && timer >0) {

            // We set the colour for the last 10 seconds as red
            stopWatch.color = Color.red;
            // We make the text blink
            stopWatch.enabled = Mathf.Round(Mathf.PingPong(Time.time * 2.0f, 1.0f)) > 0.5f;
        }

        // Set the text to be displayed
        stopWatch.text = timer.ToString("0");

        // If timer reach 0 we finished the game and display the end screen
        if (timer < 0) {
            // We load the End Scene
            SceneManager.LoadScene("EndScreen");
        }
		
	}
}
