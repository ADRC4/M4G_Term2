using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJoint : MonoBehaviour
{
    private HingeJoint tempHinge;
    bool hasJoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
            {
                tempHinge = gameObject.AddComponent<HingeJoint>();
                tempHinge.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
                tempHinge.enableCollision = true;
                hasJoint = true;
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

        //For y direction
        if (Input.GetKey(KeyCode.Alpha5))
        {
            tempHinge.anchor = new Vector3(0.5f, 0, 0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            tempHinge.anchor = new Vector3(-0.5f, 0, 0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            tempHinge.anchor = new Vector3(0.5f, 0, -0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            tempHinge.anchor = new Vector3(-0.5f, 0, -0.5f);
            tempHinge.axis = new Vector3(0, 90, 0);
        }

        ////For z direction
        //if (Input.GetKey(KeyCode.Alpha5))
        //{
        //    tempHinge.anchor = new Vector3(0, 0.5f, 0.5f);
        //    tempHinge.axis = new Vector3(90, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.Alpha6))
        //{
        //    tempHinge.anchor = new Vector3(0, 0.5f, -0.5f);
        //    tempHinge.axis = new Vector3(90, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.Alpha7))
        //{
        //    tempHinge.anchor = new Vector3(0, -0.5f, -0.5f);
        //    tempHinge.axis = new Vector3(90, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.Alpha8))
        //{
        //    tempHinge.anchor = new Vector3(0, -0.5f, 0.5f);
        //    tempHinge.axis = new Vector3(90, 0, 0);
        //}
    }
}
