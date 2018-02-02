using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController_PB : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float tumblingDuration = 0.5f;

    void Update()
    {
        var dir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector3.back;

        if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector3.right;

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }

    bool isTumbling = false;
    int count = 0;

    //private void clickCount(object sender, System.EventArgs e)
    //{
    //    KeyCode keyPress = new KeyCode();
    //    keyPress.Click += key_Press;
    //}

    //protected void key_Press(object sender, EventArgs e)
    //{
    //    count++;
    //}

    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up * 5, direction);
        var pivot = (transform.position + Vector3.down * 0.1f) + direction * 0.1f;
        var _pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    t += Time.deltaTime;
                    transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                }
                else
                {
                    t += Time.deltaTime;
                    transform.RotateAround(_pivot, rotAxis, rotSpeed * Time.deltaTime);
                }
            }
            //t += Time.deltaTime;
            //transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = endRotation;
        transform.position = endPosition;

        isTumbling = false;
    }
}
