using UnityEngine;
using System.Collections;

public class GameData {

    private static GameData instance;

    // Declaration of variable score
    private int score;
    // Declaration of variable lifes
    private int lifes;
    // Boolean variable to set the borders
    private bool activeBorders;
    // Declaration of difficulty variable
    private string difficulty;

    public static GameData Instance {
        get {
            if (instance == null) {
                instance = new GameData();
            }
            return instance;
        }
    }

    // Constructor of the class
    private GameData() {
        score = 0;
        lifes = 5;
        activeBorders = false;
        difficulty = "Medium";
    }

    // Method to get the Score
    public int getScore() {
        return score;
    }

    // Method to store the score
    public void setScore(int score) {
        this.score = score;
    }

    // Method to get the lifes
    public int getLifes() {
        return lifes;
    }

    // Method to store the score
    public void setLifes(int lifes) {
        this.lifes = lifes;
    }

    // Method to get the lifes
    public bool getActiveBorders() {
        return activeBorders;
    }

    // Method to store the score
    public void setActiveBorders(bool activeBorders) {
        this.activeBorders = activeBorders;
    }

    // Method to get the lifes
    public string getDifficulty() {
        return difficulty;
    }

    // Method to store the score
    public void setDifficulty(string difficulty) {
        this.difficulty = difficulty;
    }

}
