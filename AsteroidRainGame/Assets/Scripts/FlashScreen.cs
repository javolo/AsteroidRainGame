using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour {

    public GameObject bottomBorder;
    public GameObject topBorder;
    public GameObject leftBorder;
    public GameObject rightBorder;

    // Use this for initialization
    void Start() {

        // Initally we want the border not to appear
        bottomBorder.GetComponent<Renderer>().enabled = false;
        topBorder.GetComponent<Renderer>().enabled = false;
        leftBorder.GetComponent<Renderer>().enabled = false;
        rightBorder.GetComponent<Renderer>().enabled = false;
    }

   
    // Update is called once per frame
    void Update() {

        //Debug.Log("Game Object: " + gameObject.name + " -> Active Border: " + GameData.Instance.getActiveBorders());
        // We only display the border if it has been activated in the Boundary Effect script
        if (GameData.Instance.getActiveBorders()) {

            // When it hits the bottom of the screen we want the borders to be shown
            bottomBorder.GetComponent<Renderer>().enabled = true;
            topBorder.GetComponent<Renderer>().enabled = true;
            leftBorder.GetComponent<Renderer>().enabled = true;
            rightBorder.GetComponent<Renderer>().enabled = true;

            // We colour the border red to show the damage in lifes
            bottomBorder.GetComponent<Renderer>().material.color = Color.red;
            topBorder.GetComponent<Renderer>().material.color = Color.red;
            leftBorder.GetComponent<Renderer>().material.color = Color.red;
            rightBorder.GetComponent<Renderer>().material.color = Color.red;

            // Call the coroutine to hold the border 1 second before dissapearing
            StartCoroutine(SetFlashFalse());

            GameData.Instance.setActiveBorders(false);
        }
    }

    // Coroutine to hold the border specific amount of time before disconnect it again
    IEnumerator SetFlashFalse() {

        //Waits 1 second before setting boolean to false
        yield return new WaitForSeconds(1);
        // Set the mesh renderer back to false after that
        bottomBorder.GetComponent<Renderer>().enabled = false;
        topBorder.GetComponent<Renderer>().enabled = false;
        leftBorder.GetComponent<Renderer>().enabled = false;
        rightBorder.GetComponent<Renderer>().enabled = false;
    }

    

}
