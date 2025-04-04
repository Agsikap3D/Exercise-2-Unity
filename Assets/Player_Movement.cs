using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody rb;

    public float Force_Movement = 1000f;
    public float Force_Jump = 10000f;
    private bool Key_Press = false;
    private bool Grounded = false;

    void OnCollisionEnter(Collision collision)
    {
        Grounded = true;

    }

    void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Key_Press && Grounded)
        {
            Key_Press = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Key_Press = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
 
        if (Input.GetKey("w") && Grounded) //Move forward
        {
            Debug.Log("W is pressed"); 
            rb.AddForce(0,0,Force_Movement * Time.deltaTime);
        }

        if (Input.GetKey("s") && Grounded) //Move backward
        {
            rb.AddForce(0,0,-Force_Movement * Time.deltaTime);
        }

        if (Input.GetKey("d") && Grounded) //Move to the right
        {
            rb.AddForce(Force_Movement * Time.deltaTime, 0,0);
        }

        if (Input.GetKey("a") && Grounded) //Move to the left
        { 
            rb.AddForce(-Force_Movement * Time.deltaTime,0,0);
        }

        if (Key_Press) //Jump
        {
            rb.AddForce(0, Force_Jump * Time.deltaTime, 0);
            Key_Press=false;
        }


    }
}
