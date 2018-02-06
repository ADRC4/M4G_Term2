using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Auto : MonoBehaviour
{
    public float amount = 500f;
    public Rigidbody rb;
    //public GameObject tile;
    //private Rigidbody tile_move;
    //public float massA;
    //public float massB;
    //private Component ScriptRotate_Auto_Swip;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //tile_move = tile.GetComponent<Rigidbody>();
        //tile = GameObject.FindGameObjectWithTag("Tile");
        //rb.mass = massA;
        //tile_move.mass = massB;

        //ScriptRotate_Auto_Swip = GetComponent<Rotate_Auto_Swip>();
    }

    void Update ()
    {
        var rotAxis = Vector3.Cross(Vector3.up * 0.5f, Vector3.right);
        var rotAxis2 = Vector3.Cross(Vector3.up * 0.5f, Vector3.forward);
        float moveHorizontal = Input.GetAxis("Horizontal") * amount;
        float moveVertical = Input.GetAxis("Vertical") * amount;

        rb.AddTorque(rotAxis * moveHorizontal);
        rb.AddTorque(rotAxis2 * moveVertical);

        //// Swap the mass
        //float temp;

        //if (Input.GetKey(KeyCode.S))
        //{
        //    temp = massA;
        //    massA = massB;
        //    massB = temp;

        //    GetComponent<Rotate_Auto_Swip>().enabled = false;
        //}        
    }
}
