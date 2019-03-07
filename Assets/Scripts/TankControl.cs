using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankControl : MonoBehaviour
{
    public Vector2 inputAxis;
    public Rigidbody rb;

    public float tankMax = 4f;
    public float turnAdj;

    public float forceMod;

    public int score;
    public Text scoreText;

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

        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < tankMax)
        {
            rb.AddForce(transform.forward * inputAxis.y * forceMod, ForceMode.Impulse);
        }

        //transform.Rotate(new Vector3(0, 1, 0), inputAxis.x * turnAdj);

        transform.Rotate(new Vector3(0, 1, 0), inputAxis.x * turnAdj);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Car"))
        {
            Debug.Log(collision.gameObject.GetComponent<VerticaCollisionScript>().dmg);
            switch (collision.gameObject.GetComponent<VerticaCollisionScript>().dmg)
            {
                case 2:
                    score += 5;
                    break;
                case 3:
                    score += 10;
                    break;
                default:
                    break;
            }
            
        }
    }
}
