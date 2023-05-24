using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI;

    int score;

    public int Score
    {
        get 
        { 
            return this.score; 
        }
        set 
        { 
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get the Text UI component of this gameObject
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    //Function to update the score text UI
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }

}
