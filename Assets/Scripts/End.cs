using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Text endText;
    public Text hiScore;

    private void Awake()
    {
        if (Win.winManager.win == true)
        {
            endText.text = "YOU WON!";
            hiScore.text = "YOUR SCORE WAS: " + (int)Win.winManager.finalScore + "\n YOUR TIME WAS: " + (int)Win.winManager.finalTime;
        }
        else
        {
            endText.text = "YOU LOST!";
            hiScore.text = "YOUR SCORE WAS: " + (int)Win.winManager.finalScore;
        }
    }
        
}
