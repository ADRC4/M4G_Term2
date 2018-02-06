using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJoint2 : MonoBehaviour
{
    private HingeJoint tempHinge;
    bool hasJoint;
    Collision collision;
    Rigidbody robotRB;
    Rigidbody tileRB;
    //Vector3 boxSize;

    void Start()
    {
        //boxSize = this.GetComponent<BoxCollider>().size;
        robotRB = this.GetComponent<Rigidbody>();
        robotRB.mass = 1000;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tileRB = collision.gameObject.GetComponent<Rigidbody>();
            tileRB.mass = 1;

            if (tileRB != null && !hasJoint)
            {
                tempHinge = gameObject.AddComponent<HingeJoint>();
                tempHinge.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
                               
                tempHinge.enableCollision = true;
                hasJoint = true;
                tempHinge.anchor = new Vector3(-0.5f, 0.5f, 0);
                tempHinge.axis = new Vector3(0, 0, 90);

                var motor = tempHinge.motor;
                motor.force = 100;
                motor.targetVelocity = 100;
                motor.freeSpin = false;
                tempHinge.motor = motor;
                tempHinge.useMotor = true;
            }
        }
    }

    private void Update()
    {
        //For x direction
        if (Input.GetKey(KeyCode.Alpha1))
        {
            tempHinge.anchor = new Vector3(0.5f, 0.5f, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            tempHinge.anchor = new Vector3(-0.5f, 0.5f, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            tempHinge.anchor = new Vector3(-0.5f, -0.5f, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            tempHinge.anchor = new Vector3(0.5f, -0.5f, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }

        //For z direction
        if (Input.GetKey(KeyCode.Alpha5))
        {
            tempHinge.anchor = new Vector3(0, 0.5f, 0.5f);
            tempHinge.axis = new Vector3(90, 0, 0);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            tempHinge.anchor = new Vector3(0, 0.5f, -0.5f);
            tempHinge.axis = new Vector3(90, 0, 0); 
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            tempHinge.anchor = new Vector3(0, -0.5f, -0.5f);
            tempHinge.axis = new Vector3(90, 0, 0);
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            tempHinge.anchor = new Vector3(0, -0.5f, 0.5f);
            tempHinge.axis = new Vector3(90, 0, 0);
        }

        //For y direction
        if (Input.GetKey(KeyCode.Alpha9))
        {
            tempHinge.anchor = new Vector3(0.5f, 0, 0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);

        }
        if (Input.GetKey(KeyCode.Y))
        {
            tempHinge.anchor = new Vector3(-0.5f, 0, 0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.U))
        {
            tempHinge.anchor = new Vector3(0.5f, 0, -0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.I))
        {
            tempHinge.anchor = new Vector3(-0.5f, 0, -0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }

        //Change Mass

        if (Input.GetKey(KeyCode.F))
        {
            robotRB.mass = 1;
            tileRB.mass = 1000;
            tempHinge.axis = new Vector3(0, 0, -90);

        }
        if (Input.GetKey(KeyCode.G))
        {
            robotRB.mass = 1000;
            tileRB.mass = 1;
            tempHinge.axis = new Vector3(0, 0, 90);
        }
    }
}
