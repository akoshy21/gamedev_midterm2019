using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public float timeLeft;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Time.deltaTime);
        timeLeft -= (Time.deltaTime);

        if (timeLeft >= 0)
        {
            timerText.text = "Hey! You've got " + (int)timeLeft + " seconds left!";
        }
    }
}
