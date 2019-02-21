using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    public Vector2 inputAxis;
    public Rigidbody rb;

    public float tankMax = 4f;
    public float turnAdj;

    public float forceMod;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis.y = Input.GetAxis("Vertical");
        inputAxis.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < tankMax)
        {
            rb.AddForce(transform.forward * inputAxis.y * forceMod, ForceMode.Impulse);
        }

        this.transform.Rotate(new Vector3(0, 1, 0), inputAxis.x * turnAdj);
        //rb.AddTorque(0, inputAxis.x * turnAdj, 0, ForceMode.Impulse);

    }
}
