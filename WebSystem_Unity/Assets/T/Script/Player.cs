﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float stairsUpSpeed;
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private float jumpPower;

    private Rigidbody rigidbody;


    private bool jumpFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -angle, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, angle, 0));
        }

        if(Input.GetKey(KeyCode.W))
        {
            camera.transform.localPosition = new Vector3(-0.2f, 0.61f, 0.09f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camera.transform.localPosition = new Vector3(0.0f, 0.72f, -1.53f);
        }


        if(Input.GetKey(KeyCode.Space))
        {
            if (!jumpFlag)
            {
                rigidbody.AddForce(transform.up * jumpPower);
                jumpFlag = true;
            }
                
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Stairs")
        {
            transform.Translate(0f, 100f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //地面についている
        if(collision.gameObject.tag == "Ground")
        {
            jumpFlag = false;
        }
    }

}
