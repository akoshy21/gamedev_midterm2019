using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forceModMin, forceModMax;
    public float dist = 10;

    public float speed;

    public GameObject carFront;

    private void Start()
    {
        speed = Random.Range(forceModMin, forceModMax);
        
    }

    void Update()
    {
        CheckForCars();

        GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Force);
        
        Debug.Log("MOVE");
    }

    void CheckForCars()
    {
        Ray myRay = new Ray(this.transform.position + new Vector3(0,0,1.7f), Vector3.forward + dist * this.GetComponent<Rigidbody>().velocity);
        RaycastHit myHit;

        Debug.DrawRay(myRay.origin, Vector3.forward + this.GetComponent<Rigidbody>().velocity * dist, Color.red);

        if (Physics.Raycast(myRay, out myHit))
        {
            carFront = myHit.collider.gameObject;

            if (carFront.tag.Equals("Car"))
            {
                float hitSpeed = carFront.GetComponent<Movement>().speed;

                if (hitSpeed < speed)
                {
                    speed = hitSpeed - 10;
                }
                if (speed > hitSpeed)
                {
                    //speed -= 10;
                }

                // Debug.Log("HITS");
            }

            else if (carFront.tag.Equals("Player"))
            {
                speed = 0;
            }
        }
        else
        {
            speed = Random.Range(forceModMin, forceModMax);
            if (speed < forceModMax)
            {
                speed += Random.Range(50,100);
            }
        }
    }
}
