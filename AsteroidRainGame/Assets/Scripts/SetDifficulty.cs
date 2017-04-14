using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour {

    // Declaration of the three difficulty buttons
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    // Declaration of a variable for the default color
    private Color defaultColor;

    // Use this for initialization
    void Start () {

        // We set the default color variable
        defaultColor = new Color();
        ColorUtility.TryParseHtmlString("#FF8900FF", out defaultColor);

        // We set the colour of the difficulty we have at the beginning
        if (GameData.Instance.getDifficulty() == "Easy"){
            easyButton.GetComponent<Image>().color = Color.red;
        } else if (GameData.Instance.getDifficulty() == "Medium") {
            mediumButton.GetComponent<Image>().color = Color.red;
        } else if (GameData.Instance.getDifficulty() == "Hard") {
            hardButton.GetComponent<Image>().color = Color.red;
        }

        // Add listener to see which button we click
        Button eb = easyButton.GetComponent<Button>();
        eb.onClick.AddListener(EasyButtonClicked);

        Button mb = mediumButton.GetComponent<Button>();
        mb.onClick.AddListener(MediumButtonClicked);

        Button hb = hardButton.GetComponent<Button>();
        hb.onClick.AddListener(HardButtonClicked);

    }

    void EasyButtonClicked() {
        // We set the easy button to red
        easyButton.GetComponent<Image>().color = Color.red;
        // We set the other two buttons to the normal colour
        mediumButton.GetComponent<Image>().color = defaultColor;
        hardButton.GetComponent<Image>().color = defaultColor;

        // We set the difficulty of the button selected
        GameData.Instance.setDifficulty("Easy");
    }

    void MediumButtonClicked() {
        // We set the easy button to red
        mediumButton.GetComponent<Image>().color = Color.red;
        // We set the other two buttons to the normal colour
        mediumButton.GetComponent<Image>().color = defaultColor;
        easyButton.GetComponent<Image>().color = defaultColor;

        // We set the difficulty of the button selected
        GameData.Instance.setDifficulty("Medium");
    }

    void HardButtonClicked() {
        // We set the easy button to red
        hardButton.GetComponent<Image>().color = Color.red;
        // We set the other two buttons to the normal colour
        mediumButton.GetComponent<Image>().color = defaultColor;
        easyButton.GetComponent<Image>().color = defaultColor;

        // We set the difficulty of the button selected
        GameData.Instance.setDifficulty("Hard");
    }
}
