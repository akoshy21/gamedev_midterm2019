using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticaCollisionScript : MonoBehaviour
{
    public float forceMod;
    public Material red;
    public Material orange;

    public GameObject carBody;

    public int dmg = 1;

    private void Update()
    {
        CheckDmg();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Play");
            GetComponent<AudioSource>().Play();
            Debug.Log("COLLIDE");
            this.GetComponent<Rigidbody>().AddForce(transform.up * forceMod, ForceMode.Force);

            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (dmg < 3)
            {
                dmg++;
            }
        }
        else if (col.gameObject.tag.Equals("Car"))
        {
            GetComponent<AudioSource>().Play();
        }
    }


    // change this out from material to model
    void CheckDmg()
    {
        if (dmg == 2)
        {
            Debug.Log("ORANGE");
            carBody.GetComponent<MeshRenderer>().material = orange;
        }
        else if (dmg == 3)
        {
            carBody.GetComponent<MeshRenderer>().material = red;
            GetComponent<Movement>().enabled = false;
        }
    }
}