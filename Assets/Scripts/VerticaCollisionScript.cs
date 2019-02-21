using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticaCollisionScript : MonoBehaviour
{
    public float forceMod;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("COLLIDE");
            this.GetComponent<Rigidbody>().AddForce(transform.up * forceMod, ForceMode.Force);
        }
    }
}
