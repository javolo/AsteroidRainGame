using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour {

    // Definition of the End GUI Text variable
    public Text endText;
    // Definition of the Score GUI Text variable
    public Text scoreText;

    // Variable  that holds the score and the lives
    private GameData gameData;

    // Use this for initialization
    void Start() {

        // We create an instance of Game Data
        gameData = GameData.Instance;

        // We check the number of lifes to display one message or another
        if (gameData.getLifes() > 0) {
            // That means the time is up
            endText.text = "Time is UP!";
        } else {
            endText.text = "Game Over!";
        }

        // We set the Score Text
        scoreText.text = "Your Score: " + gameData.getScore();
    }
	
}
