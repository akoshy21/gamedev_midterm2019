using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forceMod;

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * forceMod * Time.deltaTime, ForceMode.Force);

        Debug.Log("MOVE");
    }
}
