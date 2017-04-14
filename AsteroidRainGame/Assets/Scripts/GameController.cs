using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // Declaration of Hazzard object
    public GameObject hazzard;
    // Declaration of Big Hazzard object
    public GameObject bigHazzard;

    // Declaration of starting position for hazzards
    public Vector3 spawnValues;
    // Declaration of counter variable
    public int counter;
    // Variable to wait between hazzards while spawn
    private float spawnWait;
    private float startWait = 0.5f;

    // Definition of the Score GUI Text variable
    public Text scoreText;
    // Definition of the Score variable
    private int score;

    // Definition of the Lifes GUI Text variable
    public Text lifeText;
    // Definition of Lifes variable
    private int lifes;

    // Bool variable to check if we have to display the Label or not
    private bool gameOver;

    // Float variable to see which hazzard we spawn
    private float randomizer;

    // Function called the first frame
    void Start() {

        // Initialize the score
        score = 0;
        UpdateScore();
        // Initialize the lifes
        lifes = 5;
        UpdateLifes();

        // We set the gameOver variable to false at the beginning
        gameOver = false;

        // Init the randomizer variable
        randomizer = 0;

        if (GameData.Instance.getDifficulty() == "Easy") {
            spawnWait = 0.8f;
        } else if (GameData.Instance.getDifficulty() == "Medium") {
            spawnWait = 0.5f;
        } else if (GameData.Instance.getDifficulty() == "Hard") {
            spawnWait = 0.2f;
        }

        StartCoroutine(SpawnHazzards());
    }

    // Function to spawn the hazzards in waves
    IEnumerator SpawnHazzards() {

        // Little bit of delay at the start of the game to be ready to kill all asteroids
        yield return new WaitForSeconds(startWait);

        // We´ll include here the condition of the stopwatch
        while (true) { 


            for (int i=0; i<counter; i++) {
                // Declaration of Spawn Position variable
                // We randomize the x values to go with the width of the Game Screen
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                // Declaration of Spawn Rotation as a Quaternion
                Quaternion spawnRotation = Quaternion.identity;

                // Randomly we spawn a Big Hazzard
                randomizer = Random.Range(0.0f, 1.0f);
                // If the random value is between 0 and 0,25 we create a big hazzard
                if (randomizer >= 0 && randomizer <= 0.2f) {
                    // We instantiate the hazzards
                    Instantiate(bigHazzard, spawnPosition, spawnRotation);
                } else {
                    // We instantiate the hazzards
                    Instantiate(hazzard, spawnPosition, spawnRotation);
                }
                

                // Wait a little bit until next hazzard is spawnn
                yield return new WaitForSeconds(spawnWait);
            }

            // We break the loop if the player has dead
            if (gameOver) {
                break;
            }
        }
    }

    // Public function to add the score when a hazzard it´s destroyed
    // Made it public to call externally when the hazzard exploits
    public void AddScore(int newScorevalue) {
        // Add the value passed as parameter
        score += newScorevalue;
        // Call the function to update the label score in the game
        UpdateScore();
    }

    // Function to update the score text
    void UpdateScore() {

        // We set the text to display in the screen
        scoreText.text = "Score: " + score;
    }

    // Function to update the lifes text
    void UpdateLifes() {

        // We set the text to display in the screen
        lifeText.text = "Lifes: " + lifes;
    }

    // Method to update the number of lifes
    public void RemoveLife() {
        // We remove one life from the variable
        lifes -= 1;
        // We check if the number of lifes is 0, that means that the player has lost all the lifes
        if (lifes == 0) {
            GameOver();
        }
        // Call the function to update the label score in the game
        UpdateLifes();
    }

    // Public function to be called when the player is dead
    public void GameOver() {
        // Set the variable to true to break the spawn of hazzards
        gameOver = true;

        // We add the Score generated in the game with the General one
        GameData.Instance.setScore(GameData.Instance.getScore() + score);
        // We add the Lifes remaining in the game with the General one
        GameData.Instance.setLifes(lifes);
        // We load the End Scene
        SceneManager.LoadScene("EndScreen");
    }


}
