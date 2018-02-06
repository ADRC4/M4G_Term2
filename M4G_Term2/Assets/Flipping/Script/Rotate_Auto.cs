using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Auto : MonoBehaviour
{
    public float amount = 500f;
    Rigidbody rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        //var pivot = (transform.position + Vector3.up * 0.5f) + Vector3.right * 0.5f;
        var rotAxis = Vector3.Cross(Vector3.up * 0.5f, Vector3.right);
        var rotAxis2 = Vector3.Cross(Vector3.up * 0.5f, Vector3.forward);
        float moveHorizontal = Input.GetAxis("Horizontal") * amount;
        float moveVertical = Input.GetAxis("Vertical") * amount;


        rb.AddTorque(rotAxis * moveHorizontal);
        rb.AddTorque(rotAxis2 * moveVertical);
    }
}
