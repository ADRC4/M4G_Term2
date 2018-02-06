using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAutoMovement : MonoBehaviour
{
    private HingeJoint tempHinge;
    bool hasJoint;
    Collision collision;
    Rigidbody robotRB;
    Rigidbody tileRB;
    Vector3 boxSize;

    void Start()
    {
        boxSize = this.GetComponent<BoxCollider>().size;
        robotRB = this.GetComponent<Rigidbody>();
        robotRB.mass = 10;
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
                tempHinge.anchor = new Vector3(-boxSize.x/2, boxSize.y/2, 0);
                tempHinge.axis = new Vector3(0, 0, 90);

                var motor = tempHinge.motor;
                motor.force = 100;
                motor.targetVelocity = 100;
                motor.freeSpin = false;
                tempHinge.motor = motor;
                tempHinge.useMotor = true;

                //var limits = tempHinge.limits;
                //limits.min = 0;
                //limits.bounciness = 0;
                //limits.bounceMinVelocity = 0;
                //limits.max = 200;
                //tempHinge.limits = limits;
                //tempHinge.useLimits = true;
            }
        }
    }

    void Update()
    {
        //For x direction
        if (Input.GetKey(KeyCode.Alpha1))
        {
            robotRB.mass = 10;
            tileRB.mass = 1;
            tempHinge.anchor = new Vector3(-boxSize.x / 2, boxSize.y / 2, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            robotRB.mass = 10;
            tileRB.mass = 1;
            tempHinge.anchor = new Vector3(boxSize.x/2, boxSize.y/2, 0);
            tempHinge.axis = new Vector3(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            robotRB.mass = 1;
            tileRB.mass = 10;
            tempHinge.anchor = new Vector3(boxSize.x / 2, boxSize.y / 2, 0);
            tempHinge.axis = new Vector3(0, 0, -90);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            robotRB.mass = 1;
            tileRB.mass = 10;
            tempHinge.anchor = new Vector3(-boxSize.x / 2, boxSize.y / 2, 0);
            tempHinge.axis = new Vector3(0, 0, -90);
        }
    }
}
