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
                //gameObject.AddComponent<HingeJoint>();
                //gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
                tempHinge = collision.gameObject.AddComponent<HingeJoint>();
                tempHinge.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
                tempHinge.anchor = new Vector3(0.5f, 0.5f, -0.25f);
                tempHinge.axis = new Vector3(0, 0, 90);
                hasJoint = true;
            }
        }
    }
}
