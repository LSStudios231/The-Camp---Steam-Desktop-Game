using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public Text tentNumberText;
    public int tents = 0;
    public int maxTents;
    // Start is called before the first frame update
    void Start()
    {
        tents = 0;
    }

    // Update is called once per frame
    public void AddCount(int newScore)
    {
        tents += newScore;
        UpdateCount();

        // Check if the maximum number of tents has been reached
        if (tents >= maxTents)
        {
            // Switch to a new scene
            SceneManager.LoadScene("GameWon"); // Replace "YourSceneName" with the actual scene name you want to switch to
        }
    }

    public void UpdateCount()
    {
        tentNumberText.text = "Collected tents: " + tents+"/50";
    }

    private void Update()
    {
        UpdateCount();
    }

   
}
