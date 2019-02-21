using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    public GameObject carPrefab;

    public bool[,] carHere;
    public int length, width;

    public Vector3 start, curLocation;

    private void Start()
    {
        carHere = new bool[width, length];

        GenerateCars();
        InstantiateCars();
        
    }

    void GenerateCars()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                int trueFalse = Random.Range(0, 1);

                if (i == 1)
                {
                    carHere[i, j] = true;
                }
                else
                {
                    carHere[i, j] = false;
                }
            }
        }
    }

    void InstantiateCars()
    {
        curLocation = start;

        for (int j = 0; j < length; j++)
        {
            for (int i = 0; i < width; i++)
            {
                if (carHere[i, j])
                {
                    Instantiate(carPrefab, curLocation, Quaternion.identity);
                }
                curLocation += new Vector3(1.5f, 0, 0); // adjust distances between cars
                Debug.Log("spawning " + i + carHere[i, j] + " at: " + curLocation);
            }
            curLocation = start + new Vector3(0, 0, -3.5f);
        }
    }
}
