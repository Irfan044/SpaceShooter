using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    TextMeshProUGUI timeUI;//reference to the time counter UI Text

    float startTime; //the time when the user clicks on play
    float elapsedTime; //the elapsed time after the user clicks on play
    bool startCounter;//flag to start the counter

    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false;

        //get the Text UI component from this gameObject
        timeUI = GetComponent<TextMeshProUGUI>();
    }

    //Function to start the time counter
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    //Function to stop the time counter
    public void StopTimeCounter()
    {
        startCounter= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            //compute the elapsed time
            elapsedTime = Time.time - startTime;

            minutes = (int)elapsedTime / 60; //get the minutes
            seconds = (int)elapsedTime % 60; //get the seconds

            //update the time counter UI Text
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
