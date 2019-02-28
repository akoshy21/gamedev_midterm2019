using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticaCollisionScript : MonoBehaviour
{
    public float forceMod;
    public Material red;
    public Material orange;

    public int dmg = 1;

    private void Update()
    {
        CheckDmg();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("COLLIDE");
            this.GetComponent<Rigidbody>().AddForce(transform.up * forceMod, ForceMode.Force);

            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (dmg < 3)
            {
                dmg++;
            }
        }
    }


    // change this out from material to model
    void CheckDmg()
    {
        if (dmg == 2)
        {
            Debug.Log("ORANGE");
            GetComponent<MeshRenderer>().material = orange;
        }
        else if (dmg == 3)
        {
            GetComponent<MeshRenderer>().material = red;
            GetComponent<Movement>().enabled = false;
        }
    }
}