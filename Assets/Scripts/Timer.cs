using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    int timeLeft;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Time.deltaTime);
        timer -= (Time.deltaTime);
        timerText.text = "Hey! You've got " + (int)timer + " seconds left!";

    }
}
