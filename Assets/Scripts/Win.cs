using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public static Win winManager;

    public float finalScore;
    public float finalTime;
    public GameObject player;
    public GameObject timer;

    private void Awake()
    {
        if (winManager != null && winManager != this)
        {
            Destroy(this);
        }
        else
        {
            winManager = this;
            DontDestroyOnLoad(this);
        }
    }

    void OnCollisionEnter()
    {
        if (timer.GetComponent<Timer>().timeLeft >= 0)
        {
            finalTime = timer.GetComponent<Timer>().timer - timer.GetComponent<Timer>().timeLeft;
        }
        else
        {
            finalTime = 0;
        }

        finalScore = player.GetComponent<TankControl>().score;
        SceneManager.LoadScene(1);
    }
}
